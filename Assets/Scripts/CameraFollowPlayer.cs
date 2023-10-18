using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform _cameraTransform;

    public float howFarUp;
    public float howFarBack;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        _cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _cameraTransform.position = playerTransform.position - (howFarBack * playerTransform.forward) +
                                    new Vector3(0f, howFarUp, 0f);
        _cameraTransform.forward = playerTransform.forward;
    }
}
