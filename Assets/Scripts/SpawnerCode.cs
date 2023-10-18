using UnityEngine;

public class SpawnerCode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectPrefab;
    public float howHighToSpawn;
    
    
    public void SpawnObject()
    {
        Vector3 spawnLocation = gameObject.transform.position + new Vector3(0f, howHighToSpawn, 0f);
        Quaternion rotation = objectPrefab.transform.rotation;
        Instantiate(objectPrefab, spawnLocation, rotation);
    }
}
