#include <Wire.h>
#include <Servo.h>

// Function prototypes (it looks like Arduino requires the function to be declared *before* it can be used, but only in certain cases)
int findMostUnreliableAngle(double []);
void fullSpeed();
void halfSpeed();
void stopCar();
void turn(int thetaCar);
  
// Pin numbers
int RED_RGB = 13;				// Pin for the red RGB LED
int GREEN_RGB = 11;				// Pin for the green RGB LED
int BLUE_RGB = 12;				// Pin for the blue RGB LED
int TRIG_PIN = 3;				// Transmitter pin of ultrasonic distance sensor
int ECHO_PIN = 2;				// Receiver pin of ultrasonic distance sensor
int SERVO_PIN = 10;				// Pin for the servo controlling the ultrasound sensor
int rightMotor1 = 9;            // Pin for one terminal of the car's right motor 
int rightMotor2 = 8;			// Pin for other terminal of the car's right motor
int leftMotor1 = 7;				// Pin for one terminal of the car's left motor
int leftMotor2 = 6;				// Pin for the other terminal of the car's left motor
int enable1 = 5;				// Pin for the enable on the H bridge for right motor
int enable2 = 4; 				// Pin for the enable on the H bridge for left motor

// Constants
int MAX_RANGE = 3;				// Maximum range for a set of ultrasound distance measurements to be considered reliable (greatest measurement - smallest measurement, in cm)
int SCAN_WIDTH = 10;			// Greatest angle (in degrees) to look to the right and to the left while driving straight 
								// Note: To prevent the car from stopping for obstacles way off to the side, SCAN_WIDTH should be less than arctan(SIDE_MARGIN/STOP_MARGIN), where SIDE_MARGIN is the minimum distance the car should maintain from obstacles on the side
int SLOW_MARGIN = 40;			// (in cm) If the car senses that it is within this distance of an obstacle, it will slow down to half speed.
int STOP_MARGIN = 20;			// (in cm) If the car senses that it is within this distance of an obstacle, it will stop and calculate a new path.
int GO_MARGIN = 60;				// (in cm) When the car is looking for a new path, it will move if it sees that there are no obstacles within this distance.
int timePerDegree = 10;			// milliseconds the car will turn per degree

// Non-constant global variables
int randomLight;                // Random pin number for the party
int pwm = 225;					// Pulse-width modulation controls the average voltage through a pin
int cycleStep = 0;				// Which step in the cycle is the ultrasound sensor on as it sweeps left/right (0, 2 = look straight ahead; 1 = look left; 3 = look right)
int cycleLights = 0;			// Which step in the RGB party light cycle is the program currently on (0 = red, 1 = orange, etc...)
int thetaSensor;				// Current angle (in degrees) of the ultrasound sensor (measured from the line in the direction of travel)
int thetaCar;					// Angle (in degrees) that the car must turn to avoid obstacles
String course = "CONTINUE";		// "CONTINUE" if the car should drive straight ahead at full speed, "SLOW" if it should drive straight ahead at half speed, and "STOP" if it needs to find a new path
Servo sensorServo;				// Servo to control the orientation of the servo

void setup()
{ 
  	Serial.begin(9600);	// For testing purposes
  	
  	// Initialize all pins
  	pinMode(ECHO_PIN, INPUT);
  	pinMode(TRIG_PIN, OUTPUT);
 	pinMode(rightMotor1, OUTPUT);
  	pinMode(rightMotor2, OUTPUT);
  	pinMode(leftMotor1, OUTPUT);
  	pinMode(leftMotor2, OUTPUT);
  	pinMode(enable1, OUTPUT);
  	pinMode(enable2, OUTPUT);
  	pinMode(RED_RGB, OUTPUT);
  	pinMode(GREEN_RGB, OUTPUT);
  	pinMode(BLUE_RGB, OUTPUT);
  
  	sensorServo.attach(SERVO_PIN);
  	sensorServo.write(90);	// Initialize servo and set to central position
  	delay(500);
  
  	digitalWrite(enable1, HIGH); //turns on power through enable pins of H bridge
  	digitalWrite(enable2, HIGH);
   
  	// Assuming the car is put down in the right orientation at the beginning of the course and the first turn is not too close, start motors at full speed
  	fullSpeed();
  	Serial.println("Initialization complete: starting motors");
 	flashLights();
}

void loop()
{
  	course = goingToHitStuff();
 	Serial.println(course);	
  
  	if (course == "CONTINUE")
    {
    	flashLights();
      	
      	cycleStep = (cycleStep + 1) % 4;		// Move to the next step in the cycle. If it's already at the end of the cycle, loop back to 0.
    }
  	else if (course == "SLOW")
    {
    	halfSpeed();
      	setColour(255, 255, 0); //YELLOW RGB LED!:)
      
      	cycleStep = (cycleStep + 1) % 4;		// Move to the next step in the cycle. If it's already at the end of the cycle, loop back to 0.
    }
  	else if (course == "STOP")
    {
     	stopCar();
      
      	for(int i = 0; i<3; i++)
        {
          setColour(225, 0, 0); //RED RGB LED flashes 3 times for STOP		
      	  delay(200);
          setColour(0, 0, 0);
          delay(200);
        }
        
      	thetaCar = lookAround();
      
      	turn(thetaCar); //car will turn left or right 
      
      	fullSpeed();
      	Serial.println("Starting motors");
      	for(int i=0; i<3; i++)
        {
          setColour(0, 225, 0); //GREEN RGB LED		
          delay(200);
          setColour(0, 0, 0);
          delay(200);
        }
        
      	course = "CONTINUE";
    	cycleStep = 0;	// When the car comes out of a turn, have it look forward first
    }
}


// ==================================================
// USER-DEFINED METHODS
// ==================================================


// Louis

// While the car is driving normally, scans the path ahead of the car. Returns "CONTINUE", "SLOW", or "STOP".
String goingToHitStuff()
{
	double distance;	// Distance in cm to an obstacle (in the direction of travel)
  
  	// Set the ultrasound sensor to the correct angle
  	if (cycleStep == 0 || cycleStep == 2)	// Look straight ahead
    {
    	thetaSensor = 0;
    }
  	else if (cycleStep == 1)	// Look left
    {
    	thetaSensor = SCAN_WIDTH;
    }
  	else if (cycleStep == 3)	// Look right
    {
      	thetaSensor = -SCAN_WIDTH;
    }
  	
  	Serial.print("Servo to ");
  	Serial.print(thetaSensor);
  	Serial.print(" deg - ");
  	sensorServo.write(90 + thetaSensor);	// Output the angle to the servo (add 90 because the servo considers 90 degrees to be the midpoint)
  	delay(75);			// Give the servo some time to reach the appropriate position
  	// POSSIBLE IMPROVEMENT: find the actual angular speed of the servo and calculate more precisely how long it will take (such values can be found online, but the Tinkercad servo seems *much* slower than the real ones)
  
  	// Take the distance measurement. Multiply by cos(thetaSensor) (in radians) to find the find the distance in the direction of travel.
  	distance = measureDistance() * cos(thetaSensor*3.1415926535/180);
  	Serial.print("Obstacle at ");
  	Serial.print(distance);
  	Serial.print(" cm - ");
  
    // Decide whether or not to adjust course
    if (distance < 0)		// Unreliable measurement: just keep doing the same thing
    {
  		return course;
    }
  	else if (distance <= STOP_MARGIN)	// Obstacle is within the safety margin: stop and find new path
    {
     	return "STOP";
    }
  	else if (distance <= SLOW_MARGIN)	// Obstacle is somewhat close: slow down	
    {
    	return "SLOW";  
    }
  	else	// Obstacles far away: just keep doing the same thing
    {
     	return "CONTINUE"; 
    }
}

int lookAround()
{
  	// Order in which to scan the surroundings (priority is given to angles close to +- 90 degrees under the assumption that the turns will be close to right angles)
  	int SCAN_ANGLES[] = {90, 80, 70, -90, -80, -70,
                        60, 50, 40, -60, -50, -40,
                        30, 20, 10, -30, -20, -10,
                        0
                        };
  	// Distances in cm to an obstacle (in the direction of the corresponding entry in SCAN_ANGLES)
  	double distances[19];
  	
  	// Scan the surroundings following SCAN_ANGLES until a clear path is found. 
  	for (int i = 0; i < 19; i++)
    {
        // Set ultrasound sensor to the appropriate angle and wait until it gets there
        thetaSensor = SCAN_ANGLES[i];
      	sensorServo.write(90 + thetaSensor);
      	Serial.print("Setting servo to ");
      	Serial.print(thetaSensor);
      	Serial.print(" deg - ");
      	delay(100);

        // Measure distance (but don't adjust for angle since the car will turn in that direction)
        distances[i] = measureDistance();
      
      	Serial.print(distances[i]);
      	Serial.println(" cm");
		
      	// If there's a reliable measurement indicating that obstacles are far away, turn in that direction.
        if (distances[i] > GO_MARGIN)	
        {
          	Serial.print("Turning to ");
          	Serial.print(thetaSensor);
          	Serial.println(" deg");
          	return thetaSensor;
            // POSSIBLE IMPROVEMENT: When a clear path is found for one angle, check a few degrees to either side to verify/improve the measurement. May not be necessary if the current system is already reliable.
        }
    }
  
  	// If no safe direction has been found yet, point the car towards the middle of the largest continuous range of unreliable measurements (with the hope that the obstacles are so far away in that direction they didn't register properly)
  	// POSSIBLE IMPROVEMENT: This algorithm seems like it should be the first target for improvement if the overall code doesn't perform well. In particular, it may be too slow to be practical.
  	int turnAngle = findMostUnreliableAngle(distances);
  	Serial.print("Turning to ");
    Serial.print(turnAngle);
    Serial.println(" deg...");
  	return turnAngle;
}

// Given an array of distance measurements (where unreliable measurements are denoted by -1), returns the middle index of the longest continuous streak of unreliable measurements
int findMostUnreliableAngle(double distances[])
{
 	// Sort measurements by the angle at which they were collected
  	int SORTED_SCAN_ANGLES[] = {90, 80, 70, 60, 50, 40, 30, 20, 10, 0, -10, -20, -30, -40, -50, -60, -70, -80, -90};
  	double sortedDistances[] = {distances[0], distances[1], distances[2],
                                distances[6], distances[7], distances[8],
                                distances[12], distances[13], distances[14], distances[18],
                                distances[17], distances[16], distances[15],
                                distances[11], distances[10], distances[9],
                                distances[5], distances[4], distances[3]
                               };
  	int currentStreakLength = 0;	// How many measurements in a row up to now have been unreliable?
  	int maxStreakLength = 0;		// Max number of unreliable measurements in a row
  	int endIndex;					// Final index of the longest streak of unreliable measurements
  	for (int i = 0; i < 19; i++)
    {
    	if (sortedDistances[i] == -1)	// Unreliable measurement: add one to streak
        {
         	currentStreakLength++;
           	if (currentStreakLength > maxStreakLength)	// Record index and streak length if this is the longest one so far
            {
             	maxStreakLength = currentStreakLength; 
              	endIndex = i;
            }
        }
      	else	// Reliable measurement: reset streak
        {
         	currentStreakLength = 0;
        }
    } 
  
  	// POSSIBLE IMPROVEMENT: If there are two streaks of equal length, take the one closer to +-90 degrees (currently the one that is closest to +90 degrees is taken)
  
  	return SORTED_SCAN_ANGLES[endIndex - maxStreakLength/2];
}


// Measures distance using the ultrasound sensor. Returns -1 if the measurements are considered unreliable (too much spread), else returns the distance in cm.
double measureDistance()
{
	double delta_t;		// Time (in microseconds) elapsed between signal transmission and reception
	double dist[5];		// Array of distance measurements (in cm)
  
  	// Distance measurement
    for (int i = 0; i < 5; i++)
    {
  		digitalWrite(TRIG_PIN, LOW);
        delayMicroseconds(2);

        digitalWrite(TRIG_PIN, HIGH);
        delayMicroseconds(10);
        digitalWrite(TRIG_PIN, LOW);

        delta_t = pulseIn(ECHO_PIN, HIGH);
        dist[i] = 0.0343*delta_t / 2;
      
      	delay(5);
    }
  
	// POSSIBLE IMPROVEMENT: calculate the car's speed and account for the distance travelled between pulses
  
  	// Data analysis (discard measurements if they're too far apart)
  	double minDist = min(dist[4], min(min(dist[0], dist[1]), min(dist[2], dist[3])));	// min() and max() can only take two inputs, so need to compare measurements pairwise
  	double maxDist = max(dist[4], max(max(dist[0], dist[1]), max(dist[2], dist[3])));
  	double range = maxDist - minDist;

    if (range > MAX_RANGE) {
      return -1;
    } else {
      return (dist[0] + dist[1] + dist[2] + dist[3] + dist[4]) / 5;
    }
}



//Melisa 

void fullSpeed() //full speed forward: right motor straight=straight, left motor straight=reverse
{
  analogWrite(rightMotor1, pwm);		//both motors turn at the same rate but one has to move forward and one backwards since the motors are on opposite sides of the car
  analogWrite(rightMotor2,0);
  analogWrite(leftMotor1, 0);		//first terminal on H brigge high, 2nd low: forward spin. 1rst low, second high: backwards spin
  analogWrite(leftMotor2, pwm);
  
}

void halfSpeed() //car slows down to half speed
  
{
  //both motors turn at the same rate but half the speed (half the average voltage is put in)
  int halfSpeed = (0.5*pwm);	
  
  analogWrite(rightMotor1, halfSpeed);		
  analogWrite(rightMotor2,0);
  analogWrite(leftMotor1, 0);		
  analogWrite(leftMotor2, halfSpeed);
  
  
}

void turn(int thetaCar) //car turns 
{
 //right turn: right motor reverse, left motor forward
 //for each degree, turn for 5 milliseconds (this is not precise since we can't test it, but since timePerDegree is set as a variable, it is easy to change)
  
	if(thetaCar < 0)
 	{
   		 	analogWrite(rightMotor1, 0);
   		 	analogWrite(rightMotor2, pwm);
    	 	analogWrite(leftMotor1, 0);
   		 	analogWrite(leftMotor2, pwm);
         	setColour(0, 0, 225); //BLUE RGB LED
   		 	delay(timePerDegree*abs(thetaCar));
     	
    }
  	else    //left turn: motor backwards, right forwards
    {
  		
              analogWrite(rightMotor1, pwm);
              analogWrite(rightMotor2, 0);
              analogWrite(leftMotor1, pwm);
              analogWrite(leftMotor2, 0);
              setColour(225, 0, 225); //PURPLE RGB LED
              delay(timePerDegree*abs(thetaCar));
 	}
}

void stopCar() //car stops
{
    analogWrite(rightMotor1, 0);
    analogWrite(rightMotor2, 0);
    analogWrite(leftMotor1, 0);
    analogWrite(leftMotor2, 0);
    
}
  

void flashLights()
{
  
  //RGB LED is having its own PARTY when the car is on its "CONTINUE" route!!!:)
  //flashes through the raindow with tons of shades/colour!!!
 
 cycleLights = (cycleLights + 1) % 7;
   
   int x = 15; //millisecond delay
   

  if (cycleLights == 0) 
   {
   	setColour(255, 0, 0);//red
    delay(x);
   }
  else if (cycleLights == 1)
  {
    setColour(255, 128, 0); //orange
    delay(x);
   }
   else if (cycleLights == 2) 
   {
   	setColour(255, 255, 0);//my favourite colour:)
    delay(x);
   }
  else if (cycleLights == 3) //green
   {
    setColour(0, 255, 0);
    delay(x);
   }
  else if (cycleLights == 4)
   {
    setColour(0, 0, 225); //blue
    delay(x);
   }
   else if (cycleLights == 5)
   {
   	setColour(127, 0, 255);//purple
    delay(x);
   }
  else  //pink
   {
    setColour(255, 102, 102);
    delay(x);
   }
 
  
}
 
  
 void setColour (int redColour, int greenColour, int blueColour)
{
 	analogWrite(RED_RGB, redColour);
   	analogWrite(GREEN_RGB, greenColour);
  	analogWrite(BLUE_RGB,blueColour);
}