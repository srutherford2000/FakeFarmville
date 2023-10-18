using UnityEngine;

public class BoxTriggerZone : MonoBehaviour
{
    public string boxProduceType;
    public ProduceManager thePlayerProduceManager;
    public ProduceManager theBoxProduceManager;
    public SpawnerCode theNewProduceSpawner;
    public GameObject theCharacter;

    private void OnTriggerEnter(Collider other)
    {
        if (other == theCharacter.GetComponent<CapsuleCollider>())
        {
            //move the objects from the player to the box
            int numPlayerHas = thePlayerProduceManager.GetNumberOfProduce(boxProduceType);
            int numRemoved = thePlayerProduceManager.RemoveFromManager(boxProduceType, numPlayerHas);
            int numAdded = theBoxProduceManager.AddToManager(boxProduceType, numRemoved);
            if (numAdded != numRemoved)
            {
                Debug.LogError("When moving items from player to box, something bad happened");
            }

            //spawn the new objects in the box for show
            for (int i = 0; i < numAdded; i++)
            {
                theNewProduceSpawner.SpawnObject();
            }
        }
    }
}
