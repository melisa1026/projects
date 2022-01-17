using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // player
    public Vector3 offset; // moves the position of the camera a bit in front of the target
    public Vector3 targetPosition; // target + offset
    public Vector3 modifiedTargetPosition; // new position if camera lands beyound bounds

    private Vector3 cameraPosition;

    // camera min and max bounds
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Camera cam;

    public bool activateCameraFollow;

    private float cameraHalfWidth;
    private float cameraHalfHeight;

    private void Start()
    {
        activateCameraFollow = true;

        cameraHalfHeight = cam.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * cam.aspect;
    }

    private void Update()
    {
        if (activateCameraFollow)
        {
            targetPosition = target.position + offset;

            // bottom left
            if ((targetPosition.x - cameraHalfWidth) <= minX && (targetPosition.y - cameraHalfHeight) <= minY)
            {
                modifiedTargetPosition = new Vector3(minX + cameraHalfWidth, minY + cameraHalfHeight, targetPosition.z);
                transform.position = modifiedTargetPosition;
            }
            // top left ********************************** (I need to test later that this works, cause I can't jump rn)
            else if ((targetPosition.x - cameraHalfWidth) <= minX && (targetPosition.y + cameraHalfHeight) >= maxY)
            {
                modifiedTargetPosition = new Vector3(minX + cameraHalfWidth, maxY - cameraHalfHeight, targetPosition.z);
                transform.position = modifiedTargetPosition;
            }
            // bottom right
            else if ((targetPosition.x + cameraHalfWidth) >= maxX && (targetPosition.y - cameraHalfHeight) <= minY)
            {
                modifiedTargetPosition = new Vector3(maxX - cameraHalfWidth, minY + cameraHalfHeight, targetPosition.z);
                transform.position = modifiedTargetPosition;
            }
            // top right ********************************** (I need to test later that this works, cause I can't jump rn)
            else if ((targetPosition.x + cameraHalfWidth) >= maxX && (targetPosition.y + cameraHalfHeight) >= maxY)
            {
                modifiedTargetPosition = new Vector3(maxX - cameraHalfWidth, maxY - cameraHalfHeight, targetPosition.z);
                transform.position = modifiedTargetPosition;
            }
            // bottom middle
            else if ((targetPosition.y - cameraHalfHeight) <= minY)
            {
                modifiedTargetPosition = new Vector3(targetPosition.x, minY + cameraHalfHeight, targetPosition.z);
                transform.position = modifiedTargetPosition;
            }
            // top middle ********************************** (I need to test later that this works, cause I can't jump rn)
            else if ((targetPosition.y + cameraHalfHeight) >= maxY)
            {
                modifiedTargetPosition = new Vector3(targetPosition.x, maxY - cameraHalfHeight, targetPosition.z);
                transform.position = modifiedTargetPosition;
            }
            // right middle ********************************** (I need to test later that this works, cause I can't jump rn)
            else if ((targetPosition.x + cameraHalfWidth) >= maxX)
            {
                modifiedTargetPosition = new Vector3(maxX - cameraHalfWidth, targetPosition.y, targetPosition.z);
                transform.position = modifiedTargetPosition;
            }
            // left middle ********************************** (I need to test later that this works, cause I can't jump rn)
            else if ((targetPosition.x - cameraHalfWidth) <= minX)
            {
                modifiedTargetPosition = new Vector3(minX + cameraHalfWidth, targetPosition.y, targetPosition.z);
                transform.position = modifiedTargetPosition;
            }
            else
                transform.position = target.position + offset; // script's object position = same position of target object
        }
    }

   
}
