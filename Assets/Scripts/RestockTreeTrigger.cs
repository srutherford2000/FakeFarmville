using UnityEngine;

public class RestockTreeTrigger : MonoBehaviour
{
    
    private CapsuleCollider _theCharacterCapsuleCollider;

    public GameObject theTree;
    // Start is called before the first frame update
    void Start()
    {
        _theCharacterCapsuleCollider = GameObject.Find("thePlayer").GetComponent<CapsuleCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == _theCharacterCapsuleCollider)
        {
            //set the tree back to active
            theTree.SetActive(true);
        }
    }
}
