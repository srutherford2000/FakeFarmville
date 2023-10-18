using System.Collections.Generic;
using UnityEngine;

public class RestockFieldTrigger : MonoBehaviour
{
    
    private CapsuleCollider _theCharacterCapsuleCollider;

    public List<GameObject> thePlants;
    // Start is called before the first frame update
    void Start()
    {
        _theCharacterCapsuleCollider = GameObject.Find("thePlayer").GetComponent<CapsuleCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == _theCharacterCapsuleCollider)
        {
            //we need to remove the old one and make a new one
            foreach (GameObject plant in thePlants)
            {
                plant.SetActive(true);
            }
            
        }
    }
}
