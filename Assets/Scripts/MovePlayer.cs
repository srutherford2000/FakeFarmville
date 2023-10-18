using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Animator theAnimator ;
    private Transform _theTransform;
    public float moveSpeed;
    public float rotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the animator component
        theAnimator = GetComponent<Animator>();
        _theTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        if (move != 0f)
        {
            theAnimator.SetBool("isWalking", true);
            _theTransform.Translate(new Vector3(0f, 0f, move));
            _theTransform.Rotate(new Vector3(0f, rotation, 0f));
        }
        else
        {
            theAnimator.SetBool("isWalking", false);
        }
        

    }
}
