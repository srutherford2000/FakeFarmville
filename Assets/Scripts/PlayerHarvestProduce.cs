using UnityEngine;

public class PlayerHarvestProduce : MonoBehaviour
{
    // Start is called before the first frame update
    public GlobalVariableManager theGlobalVariables;
    public ProduceManager thePlayerProduceManager;


    private void OnTriggerEnter(Collider other)
    {
        GameObject collidingObject = other.gameObject;
        if (collidingObject.CompareTag("Tree"))
        {
            HandleTreeCollision(collidingObject);
        }
        else
        {
            foreach (GlobalVariableManager.ProduceInfo theInfo in theGlobalVariables.TheProduceValues)
            {
                //Now you can access the key and value both separately from this attachStat as:
                string theProduceVal = theInfo.Name;
                string theTagVal = theInfo.TagName;
                if (collidingObject.CompareTag(theTagVal))
                {
                    HandleCollision(collidingObject, theProduceVal);
                }
            }
        }
    }

    private void HandleTreeCollision(GameObject theObject)
    {
        Debug.Log("handling tree");
        //deactivate the tree
        theObject.SetActive(false);
        
        //activate the 9 apples
        foreach (GameObject apple in theObject.GetComponent<AppleManager>().listOfApples)
        {
            apple.SetActive(true);
        }
    }

private void HandleCollision(GameObject theObject, string theProduce)
    {
        //we should add the new produce to the manager
        thePlayerProduceManager.AddToManager(theProduce,1);
        
        //make the object not active
        theObject.SetActive(false);
    }
}
