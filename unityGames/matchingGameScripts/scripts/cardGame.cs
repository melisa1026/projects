using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class cardGame : MonoBehaviour
{
    public Sprite[] images = new Sprite[20];

    public GameObject[] cards = new GameObject[0];

    private int[] openCards = new int[40];   // checks if each card was opened
    private int[] matches = new int[20];     // checks how many of each sprite was open

    private bool findImage = false; // if mercedes found a match

    private int turnCount = 0;
    private float halfLength = 0.75f; // card size
    private Vector3 mouseSpot;
    private Transform tempTransform;
    private int numFlipped = 0;
    private GameObject flipped1, flipped2;
    private int matched1, matched2; // used to delete cards after they're matched
    private bool isMovingCards = false, growing = false, shrinking = false;
    private Random random = new System.Random();
    private int chosenNum1, chosenNum2; // used by computer
    private int playerScore = 0, compScore = 0;
    public Text playerScoreText, compScoreText, resultText;

    private int spriteNum = 0; // the number on images[] of the sprite that has a match
    private int matchProbability;
    private int willSheCheat; // random number that determines if sonya will cheat
    private string opponent;
    public Animator sonyaAnim;

    public GameObject playerImage, opponentImage;

    public Sprite[] characterSprites;

    public Button playAgainButton;
    public Text playAgainText;

    void Start()
    {
        Debug.Log(globalVariables.player + " and " + globalVariables.opponent);
        // set the opponent
        opponent = globalVariables.opponent;

        // choose the sprites for the player
        if (globalVariables.player == "melisa")
        {
            playerImage.GetComponent<SpriteRenderer>().sprite = characterSprites[0];
        }
        else if (globalVariables.player == "mercedes")
        {
            playerImage.GetComponent<SpriteRenderer>().sprite = characterSprites[1];
        }
        else if (globalVariables.player == "pauline")
        {
            playerImage.GetComponent<SpriteRenderer>().sprite = characterSprites[2];
        }
        else if (globalVariables.player == "sonya")
        {
            playerImage.GetComponent<SpriteRenderer>().sprite = characterSprites[3];
        }
        else if (globalVariables.player == "evelyn")
        {
            playerImage.GetComponent<SpriteRenderer>().sprite = characterSprites[4];
        }

        // choose the sprites for the opponent
        if (opponent == "melisa")
        {
            opponentImage.GetComponent<SpriteRenderer>().sprite = characterSprites[0];
        }
        else if (opponent == "mercedes")
        {
            opponentImage.GetComponent<SpriteRenderer>().sprite = characterSprites[1];
        }
        else if (opponent == "pauline")
        {
            opponentImage.GetComponent<SpriteRenderer>().sprite = characterSprites[2];
        }
        else if (opponent == "sonya")
        {
            opponentImage.GetComponent<SpriteRenderer>().sprite = characterSprites[3];
        }
        else if (opponent == "evelyn")
        {
            opponentImage.GetComponent<SpriteRenderer>().sprite = characterSprites[4];
        }

        int count = 0;

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                SpriteRenderer sevenUp = cards[count].GetComponent<SpriteRenderer>();

                sevenUp.sprite = images[i];

                count++;
            }
        }

        for (int i = 0; i < 40; i++)
        {
            int temp = random.Next(40);

            SpriteRenderer drPepper = cards[i].GetComponent<SpriteRenderer>();
            SpriteRenderer drSalt = cards[temp].GetComponent<SpriteRenderer>();

            Sprite temp2 = drPepper.sprite;

            drPepper.sprite = drSalt.sprite;
            drSalt.sprite = temp2;
        }

        for (int i = 0; i < 40; i++)
        {
            openCards[i] = 0;
        }

        for (int i = 0; i < 20; i++)
        {
            matches[i] = 0;
        }
    }






    void Update()
    {
        if ((playerScore + compScore) == 20)
        {
            if (playerScore == compScore)
                resultText.text = "Tie";
            else if (playerScore > compScore)
                resultText.text = "You Win";
            else
                resultText.text = "You Lose";

            enableButton();

            turnCount++;
        }
        else if ((playerScore + compScore) > 20)
        {
            StartCoroutine(grow(playerImage));
            StartCoroutine(shrink(playerImage));
            StartCoroutine(grow(opponentImage));
            StartCoroutine(shrink(opponentImage));

        }
        else
        {
            if (turnCount % 2 == 0)
            {
                StartCoroutine(playerTurn());

                StartCoroutine(grow(playerImage));
                StartCoroutine(shrink(opponentImage));
                
            }
            else
            {
                if (opponent == "melisa" || opponent == "evelyn" || opponent == "sonya")
                    StartCoroutine(melEvyTurn());
                else if (opponent == "mercedes")
                    StartCoroutine(mercedesTurn());
                else // pauline
                    StartCoroutine(paulineTurn());

                StartCoroutine(shrink(playerImage));
                StartCoroutine(grow(opponentImage));
            }
        }
    }






    public IEnumerator playerTurn()
    {
        mouseSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // if the mouse is pressed
        if (Input.GetMouseButtonUp(0) && flipped2 == null && !isMovingCards)
        {
            // check which card the mouse is on
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] != null)
                {
                    float positionx = cards[i].transform.position.x;
                    float positiony = cards[i].transform.position.y;

                    if (mouseSpot.x > (positionx - halfLength) && mouseSpot.x < (positionx + halfLength) &&
                        mouseSpot.y > (positiony - halfLength) && mouseSpot.y < (positiony + halfLength))
                    {
                        // if the second card is being chosen and it is the same as the first card
                        if (flipped1 != null && flipped2 == null && i == matched1)
                        { }
                        else
                        {
                            // if the card has not yet been opened
                            if (openCards[i] == 0)
                            {
                                // get the sprite of the opened card
                                Sprite tempRend = cards[i].GetComponent<SpriteRenderer>().sprite;

                                // find the index of its matching sprite
                                for (int j = 0; j < 20; j++)
                                {
                                    // mark that the sprite has been opened one more time
                                    if (tempRend == images[j])
                                    {
                                        matches[j]++;
                                    }
                                }

                                // mark card open
                                openCards[i] = 1;
                            }

                            StartCoroutine(flipCard(cards[i]));
                            numFlipped++;
                            if (numFlipped == 1)
                            {
                                flipped1 = cards[i];
                                matched1 = i;
                            }
                            else
                            {
                                flipped2 = cards[i];
                                matched2 = i;
                            }
                        }
                    }
                }
            }
         
        }

        if (numFlipped == 2)
        {
            numFlipped = 0;

            // get the sprites of each card
            Sprite spr1 = flipped1.GetComponent<SpriteRenderer>().sprite;
            Sprite spr2 = flipped2.GetComponent<SpriteRenderer>().sprite;


            // check if the cards are a match
            if (spr1 == spr2)
            {
                // find the sprite number of the match
                for (int k = 0; k < 20; k++)
                {
                    if (images[k] == spr1)
                        spriteNum = k;
                }
                matches[spriteNum] = -1;
                StartCoroutine(match(flipped1, flipped2));
            }
            else
            {
                yield return new WaitForSeconds(1);

                // flip cards back
                StartCoroutine(flipCard(flipped1));
                StartCoroutine(flipCard(flipped2));

                turnCount++;
            }

            flipped1 = null;
            flipped2 = null;
        }
    }




    // chooses random each time
    public IEnumerator paulineTurn()
    {
        // prevents ethod from being called more than once a turn
        if (isMovingCards == false)
        { 
            // prevents player from moving
            isMovingCards = true;

            yield return new WaitForSeconds(1);

            // choose first card
            chosenNum1 = random.Next(40);
            while (cards[chosenNum1] == null)
            {
                chosenNum1 = random.Next(40);
            }
            matched1 = chosenNum1;

            StartCoroutine(flipCard(cards[chosenNum1]));

            yield return new WaitForSeconds(1);

            // choose second card
            chosenNum2 = random.Next(40);
            while (cards[chosenNum2] == null || chosenNum1 == chosenNum2)
            {
                chosenNum2 = random.Next(40);
            }
            matched2 = chosenNum2;

            StartCoroutine(flipCard(cards[chosenNum2]));

            yield return new WaitForSeconds(1);

            // get the sprite renderers of both cards
            SpriteRenderer ren1 = cards[chosenNum1].GetComponent<SpriteRenderer>();
            SpriteRenderer ren2 = cards[chosenNum2].GetComponent<SpriteRenderer>();

            // check if crads are a match
            if (ren1.sprite == ren2.sprite)
            {

                StartCoroutine(match(cards[chosenNum1], cards[chosenNum2]));
            }
            else
            {
                StartCoroutine(flipCard(cards[chosenNum1]));
                StartCoroutine(flipCard(cards[chosenNum2]));
                isMovingCards = false;
                turnCount++;
            }
        }
    }



    



    // PS: good luck
    public IEnumerator mercedesTurn()
    {

        // prevents method from being called more than once a turn
        if (isMovingCards == false)
        {
            // prevents player from moving
            isMovingCards = true;

            yield return new WaitForSeconds(1); 
            
            Sprite toOpenSprite = null;

            for (int i = 0; i < 20; i++)
            {
                    if (matches[i] == 2)
                    {
                        toOpenSprite = images[i];
                        spriteNum = i;
                        findImage = true;
                    }
            }
            if (findImage)
            {
                // reset
                findImage = false;

                matched1 = -1;
                matched2 = -1;

                // sprites of the current card
                SpriteRenderer Sonya;
                Sprite Melisa;

                for (int i = 0; i < 40; i++)
                {
                    if (cards[i] != null)
                    {
                        // get the sprite of this card
                        Sonya = cards[i].GetComponent<SpriteRenderer>();
                        Melisa = Sonya.sprite;

                        if (toOpenSprite == Melisa)
                        {
                            if (matched1 == -1)
                            {
                                matched1 = i;
                            }
                            else
                                matched2 = i;
                        }
                    }
                }
            }
            else
            {
                // choose first card
                chosenNum1 = random.Next(40);
                while (cards[chosenNum1] == null)
                {
                    chosenNum1 = random.Next(40);
                }
                matched1 = chosenNum1;

                // choose second card
                chosenNum2 = random.Next(40);
                while (cards[chosenNum2] == null || chosenNum1 == chosenNum2)
                {
                    chosenNum2 = random.Next(40);
                }
                matched2 = chosenNum2;

            }

            // even through i set it up so matched1 and 2 always get initialized beyond -1, they were occasionally still ending up as -1. So if this is
            // the case, just choose random
            if(matched1 == -1 || matched2 == -1)
            {

                // set it so that the match that failed isn't searched for again
                matches[spriteNum] = 0;

                // choose first card
                chosenNum1 = random.Next(40);
                while (cards[chosenNum1] == null)
                {
                    chosenNum1 = random.Next(40);
                }
                matched1 = chosenNum1;

                // choose second card
                chosenNum2 = random.Next(40);
                while (cards[chosenNum2] == null || chosenNum1 == chosenNum2)
                {
                    chosenNum2 = random.Next(40);
                }
                matched2 = chosenNum2;

            }

            // card 1
            // if the card has not yet been opened
            if (openCards[matched1] == 0)
            {
                // get the sprite of the opened card
                Sprite tempRend = cards[matched1].GetComponent<SpriteRenderer>().sprite;

                // find the index of its matching sprite
                for (int j = 0; j < 20; j++)
                {
                    // mark that the sprite has been opened one more time
                    if (tempRend == images[j])
                    {
                        matches[j]++;
                    }
                }

                // mark card open
                openCards[matched1] = 1;
            }

            // card 2
            // if the card has not yet been opened
            if (openCards[matched2] == 0)
            {
                // get the sprite of the opened card
                Sprite tempRend = cards[matched2].GetComponent<SpriteRenderer>().sprite;

                // find the index of its matching sprite
                for (int j = 0; j < 20; j++)
                {
                    // mark that the sprite has been opened one more time
                    if (tempRend == images[j])
                    {
                        matches[j]++;
                    }
                }

                // mark card open
                openCards[matched2] = 1;
            }

            // flip the cards
            StartCoroutine(flipCard(cards[matched1]));
            yield return new WaitForSeconds(1);
            StartCoroutine(flipCard(cards[matched2]));
            yield return new WaitForSeconds(1);

            // get the sprite renderers of both cards
            SpriteRenderer ren1 = cards[matched1].GetComponent<SpriteRenderer>();
            SpriteRenderer ren2 = cards[matched2].GetComponent<SpriteRenderer>();

            // check if crads are a match
            if (ren1.sprite == ren2.sprite)
            {
                matches[spriteNum] = -1;
                StartCoroutine(match(cards[matched1], cards[matched2]));
            }
            else
            {
                StartCoroutine(flipCard(cards[matched1]));
                StartCoroutine(flipCard(cards[matched2]));
                isMovingCards = false;
                turnCount++;
            }
        }
    }




    public IEnumerator melEvyTurn()
    {
        // prevents method from being called more than once a turn
        if (isMovingCards == false)
        {
            isMovingCards = true;

            // if it's sonyas turn, she can cheat
            if (opponent == "sonya")
            {
                willSheCheat = random.Next(10);

                if (willSheCheat == 0)
                {
                    yield return new WaitForSeconds(1);

                    // choose a random card and flip it, then flip it back
                    chosenNum1 = random.Next(40);
                    while (cards[chosenNum1] == null)
                    {
                        chosenNum1 = random.Next(40);
                    }
                    matched1 = chosenNum1;

                    StartCoroutine(flipCard(cards[matched1]));
                    yield return new WaitForSeconds(1);
                    StartCoroutine(flipCard(cards[matched1]));

                    StartCoroutine(sonyaCheatFace());
                }
            }

            // every round the probability of getting a match increases. starts at 1/21
            matchProbability = 24 - (playerScore + compScore);

            int willChooseRandom = random.Next(matchProbability);
            Debug.Log(matchProbability + ":" + willChooseRandom);

            // if sonya is opening an extra card, she'll get a match
            if (opponent == "sonya" && willSheCheat == 0)
                willChooseRandom = 0;

            // choose a random number in the match probability. If the number is 0, match will be found
            if (willChooseRandom == 0 || willChooseRandom == 1 || willChooseRandom == 4)
            {
                // choose first cards
                matched1 = random.Next(40);
                while (cards[matched1] == null)
                {
                    matched1 = random.Next(40);
                }

                Sprite chosenSprite = cards[matched1].GetComponent<SpriteRenderer>().sprite;
                Sprite matchingSprite;

                // get the sprite of the random card and find its match
                for (int i = 0; i < 40; i++)
                {
                    // don't wanna match a card with itself
                    if (i != matched1 && cards[i] != null)
                    {
                        matchingSprite = cards[i].GetComponent<SpriteRenderer>().sprite;

                        if (matchingSprite == chosenSprite)
                            matched2 = i;
                    }
                }
            }
            // if match probability random give a non zero number, choose random cards
            else
            {
                // choose first card
                chosenNum1 = random.Next(40);
                while (cards[chosenNum1] == null)
                {
                    chosenNum1 = random.Next(40);
                }
                matched1 = chosenNum1;

                // choose second card
                chosenNum2 = random.Next(40);
                while (cards[chosenNum2] == null || chosenNum1 == chosenNum2)
                {
                    chosenNum2 = random.Next(40);
                }
                matched2 = chosenNum2;
            }

            // flip the cards
            yield return new WaitForSeconds(1);
            StartCoroutine(flipCard(cards[matched1]));
            yield return new WaitForSeconds(1);
            StartCoroutine(flipCard(cards[matched2]));
            yield return new WaitForSeconds(1);

            if (opponent == "sonya")
            {
                if (willSheCheat == 1 && playerScore > 0)
                {
                    // steal a point from player
                    playerScore--;
                    playerScoreText.text = playerScore.ToString();

                    compScore++;
                    compScoreText.text = compScore.ToString();

                    StartCoroutine(sonyaCheatFace());

                    yield return new WaitForSeconds(1);
                }
            }

            // get the sprite renderers of both cards
            SpriteRenderer ren1 = cards[matched1].GetComponent<SpriteRenderer>();
            SpriteRenderer ren2 = cards[matched2].GetComponent<SpriteRenderer>();

            // check if cards are a match
            if (ren1.sprite == ren2.sprite)
            {
                matches[spriteNum] = -1;
                StartCoroutine(match(cards[matched1], cards[matched2]));
            }
            else
            {
                StartCoroutine(flipCard(cards[matched1]));
                StartCoroutine(flipCard(cards[matched2]));
                isMovingCards = false;
                turnCount++;
            }
        }
    }



    public IEnumerator flipCard(GameObject card)
    {

        // get the card transform component

        Transform cardTransform = card.GetComponent<Transform>();

        // get the child card
        GameObject child = card.transform.GetChild(0).gameObject;

        // get the sprite renderers of the card and its child
        SpriteRenderer cardSpriteRen = card.GetComponent<SpriteRenderer>();
        SpriteRenderer childSpriteRen = child.GetComponent<SpriteRenderer>();

        // get the sorting layer names
        string cardLay = cardSpriteRen.sortingLayerName;
        string childLay = childSpriteRen.sortingLayerName;

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.0001f);

            cardTransform.Rotate(0, 18, 0, Space.World);

            if (i == 9)
            {
                cardSpriteRen.sortingLayerName = childLay;
                childSpriteRen.sortingLayerName = cardLay;
            }
        }
    }





    public IEnumerator match(GameObject card1, GameObject card2)
    {
        isMovingCards = true;



            yield return new WaitForSeconds(1);
        // put the cards on the top layer
        SpriteRenderer rend1 = card1.GetComponent<SpriteRenderer>();
        SpriteRenderer rend2 = card2.GetComponent<SpriteRenderer>();
        rend1.sortingLayerName = "chosenCard";
        rend2.sortingLayerName = "chosenCard";

        // determine how much the image has to scale up and the direction it must move to be in position (0, 0, -1) and scale(5.3, 5.3, 5.3)
        // transition over 20 frames

        // get the transform of each card
        Transform transform1 = card1.GetComponent<Transform>();
        Transform transform2 = card2.GetComponent<Transform>();

        Vector3 pos1 = transform1.position;
        Vector3 pos2 = transform2.position;

        Vector3 scale1 = transform1.localScale;
        Vector3 scale2 = transform2.localScale;

        Vector3 posPerFrame1 = new Vector3(-1 * pos1.x / 20, -1 * pos1.y / 20, 0);
        Vector3 posPerFrame2 = new Vector3(-1 * pos2.x / 20, -1 * pos2.y / 20, 0);

        Vector3 scalePerFrame1 = new Vector3((0.7f - scale1.x) / 20, (0.7f - scale1.y) / 20, 0);
        Vector3 scalePerFrame2 = new Vector3((0.7f - scale2.x) / 20, (0.7f - scale2.y) / 20, 0);

        // 20 frames
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.01f);

            // move 1 frames worth
            transform1.position = new Vector3(pos1.x + posPerFrame1.x, pos1.y + posPerFrame1.y, 0);
            transform2.position = new Vector3(pos2.x + posPerFrame2.x, pos2.y + posPerFrame2.y, 0);

            // scale 1 frames worth
            transform1.localScale = new Vector3(scale1.x + scalePerFrame1.x, scale1.y + scalePerFrame1.y, 0);
            transform2.localScale = new Vector3(scale2.x + scalePerFrame2.x, scale2.y + scalePerFrame2.y, 0);

            // reset the position and scale values to the new spots
            pos1 = transform1.position;
            pos2 = transform2.position;
            scale1 = transform1.localScale;
            scale2 = transform2.localScale;

        }

        yield return new WaitForSeconds(2);

        // add match to score
        if (turnCount % 2 == 0)
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
        }
        else
        {
            compScore++;
            compScoreText.text = compScore.ToString();
        }

        // removing the cards
        // get the second side of the cards
        GameObject child1 = cards[matched1].transform.GetChild(0).gameObject;
        GameObject child2 = cards[matched2].transform.GetChild(0).gameObject;

        // get the other side of the cards' sprite renderers sprite renderers
        SpriteRenderer childRend1 = child1.GetComponent<SpriteRenderer>();
        SpriteRenderer childRend2 = child2.GetComponent<SpriteRenderer>();

        // remove the images
        rend1.sprite = null;
        rend2.sprite = null;
        childRend1.sprite = null;
        childRend2.sprite = null;

        // delete the two cards
        cards[matched1] = null;
        cards[matched2] = null;

        isMovingCards = false;
        turnCount++;

    }

    public IEnumerator grow(GameObject person)
    {
        // grow 0.00843621/frame for 10 frames

        Transform personTrans = person.GetComponent<Transform>();

        if (!growing && personTrans.localScale.x < 0.3f)
        {
            growing = true;
            
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(0.01f);
                personTrans.localScale = new Vector3(personTrans.localScale.x + 0.00843621f, personTrans.localScale.y + 0.00843621f, 
                                                                                                    personTrans.localScale.z + 0.00843621f);
            }

            growing = false;
        }
    }

    public IEnumerator shrink(GameObject person)
    {
        Transform personTrans = person.GetComponent<Transform>();

        if (!shrinking && personTrans.localScale.x > 0.3f)
        {
            shrinking = true; 

            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(0.01f);
                personTrans.localScale = new Vector3(personTrans.localScale.x - 0.00843621f, personTrans.localScale.y - 0.00843621f,
                                                                                                    personTrans.localScale.z - 0.00843621f);
            }

            shrinking = false;
        }

    }

    public IEnumerator sonyaCheatFace()
    {
        sonyaAnim.enabled = true;
        yield return new WaitForSeconds(2);
        sonyaAnim.enabled = false;

        opponentImage.GetComponent<SpriteRenderer>().sprite = characterSprites[3];
    }

    public void nextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void enableButton()
    {
        playAgainButton.GetComponent<Image>().enabled = true;
        playAgainButton.enabled = true;
        playAgainText.enabled = true;
    }
}