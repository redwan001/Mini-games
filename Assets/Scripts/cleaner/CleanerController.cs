using UnityEngine;
using DG.Tweening;

public class CleanerController : MonoBehaviour
{
    public float speed = 15f;
    public float radius;
    public Transform visuals;

    [Header("Player Controlling Required Values")]
    private Vector3 deviation;
    private Vector3 moveDirection = Vector3.zero;
    public float sensitivity = 300f;
    public float turnTreshold = 15f;
    private Vector3 mouseStartPosition;
    private Vector3 mouseCurrentPosition;
    protected Quaternion targetRotation;
    public float movementSmoothing = .02f;
    public float rotationSmoothing = .01f;
    private bool isCollided;

    private Animator LevelPassedAnim;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        isCollided = false;
        rotationSmoothing = rotationSmoothing - .05f;
        LevelPassedAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
       PlayerMovementControl();
        
    }

    public void PlayerMovementControl()
    {

        /* if (GameManager.instance.hasPassedLevel)
         {
             return;
         }
         else
         {*/
        mouseCurrentPosition = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                mouseStartPosition = mouseCurrentPosition;
            }

            if (!isCollided)
            {
                if (Input.GetMouseButton(0))
                {
                    anim.Play("Run");

                    float distance = (mouseCurrentPosition - mouseStartPosition).magnitude;

                    if (distance > turnTreshold)
                    {
                        if (distance > sensitivity)
                        {
                            mouseStartPosition = mouseCurrentPosition - (moveDirection * sensitivity);
                        }

                        Vector3 currentDirection = -(mouseStartPosition - mouseCurrentPosition).normalized;
                        moveDirection.x = Mathf.Lerp(moveDirection.x, currentDirection.x, movementSmoothing);
                        moveDirection.z = Mathf.Lerp(moveDirection.z, currentDirection.y, movementSmoothing);
                        moveDirection.y = 0f;

                    }
                    targetRotation = Quaternion.LookRotation(moveDirection);

                    if (visuals.rotation != targetRotation)
                    {
                        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, 360f, 0f) * Time.smoothDeltaTime);
                        visuals.rotation = Quaternion.Slerp(visuals.rotation, targetRotation * deltaRotation, rotationSmoothing);
                    }
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                moveDirection = Vector3.zero;
                anim.Play("Idle");
            }
            deviation = moveDirection * speed * 20f * Time.deltaTime;
            transform.SetPositionAndRotation(transform.position + deviation, transform.rotation);
      //  }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            isCollided = true;
            Vector3 currentPosition = new Vector3(visuals.parent.transform.position.x, visuals.parent.transform.position.y, visuals.parent.transform.position.z);
            visuals.parent.DOMove(currentPosition, .3f).OnComplete(()=>
            {
                isCollided = false;
            });
        }

        if(other.tag == "CheckPoint")
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
          //  GameManager.instance.hasPassedLevel = true;
            LevelPassedAnim.enabled = true;
        
        }
        if(other.tag == "Luggage")
        {
            print("----------");
        }
    }

    public void DisableColliderifNeeded()
    {
        this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = false;
    }

    public void EnableColliderifNeeded()
    {
        this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = true;
    }


}
