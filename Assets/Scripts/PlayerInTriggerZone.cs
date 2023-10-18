using UnityEngine;

public class PlayerInTriggerZone : MonoBehaviour
{

    public CapsuleCollider thePersonCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other == thePersonCollider)
        {
            Debug.Log("WE HAVE A HIT");
        }
    }
}
