using UnityEngine;

public class MoveTruckManager : MonoBehaviour
{
    public float moveForwardMultiplier;

    private readonly int _startZ = 20;
    private readonly int _getTaskZ = 0;
    private readonly int _stopZ = -20;

    public int currentState;

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        if ((currentState == 0) && (currentPos.z > _getTaskZ))
        {
            MoveTruckForward();
        }
        else if (currentState == 0)
        {
            currentState = 1;
        }
        else if (currentState == 1 || currentState == 2)
        {
            //were waiting on action from task manager this is fine
        }
        else if ((currentState == 3) && (currentPos.z > _stopZ))
        {
            MoveTruckForward();
        }
        else if (currentState == 3)
        {
            currentState = 0;
            transform.position = new Vector3(currentPos.x, currentPos.y, _startZ);
        }
        else
        {
            Debug.LogError("We got into a weird state for the truck movement");
        }
    }

    private void MoveTruckForward()
    {
        float theMovedZ = moveForwardMultiplier * Time.deltaTime;
        transform.position -= new Vector3(0f, 0f, theMovedZ);
    }
}
