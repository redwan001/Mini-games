
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class CollectorController : MonoBehaviour
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
    

    //need to Transfer the below-line codes 
    public Transform[] fruitOnCartPosition;
    private List<Transform> fruitsPosition;
    private int fruitCount;
    private int stackFilled;
    public Transform cartPos;
    public GameObject magicPoofFx;
    // Start is called before the first frame update
    void Start()
    {
        fruitCount = 0;
        fruitsPosition = new List<Transform>();
        stackFilled = 0;        
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovementControl();

    }

    public void PlayerMovementControl()
    {

        /*if (GameManager.instance.hasPassedLevel)
        {
            return;
        }
        else
        {*/
        //Camera.main.transform.LookAt(this.gameObject.transform);

        if (Manager.sharedManager().isGameOver)
            return;
        else
        {
            mouseCurrentPosition = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                mouseStartPosition = mouseCurrentPosition;
            }

            if (Input.GetMouseButton(0))
            {

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
            if (Input.GetMouseButtonUp(0))
            {
                moveDirection = Vector3.zero;
            }
            deviation = moveDirection * speed * 20f * Time.deltaTime;
            transform.SetPositionAndRotation(transform.position + deviation, transform.rotation);
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Collider>().enabled = false;
        Instantiate(magicPoofFx, collision.gameObject.transform.position,Quaternion.identity);
        CheckIfoodPositionExceed();
        switch (collision.gameObject.tag)
        {
            case "Apple":
                Destroy(collision.gameObject);
                Instantiate(Manager.sharedManager().apples, fruitsPosition[fruitCount]);
                
                break;
            case "Coconut":
                Destroy(collision.gameObject);
                Instantiate(Manager.sharedManager().coconut, fruitsPosition[fruitCount]);
                
                break;
            case "Orange":
                Destroy(collision.gameObject);
                Instantiate(Manager.sharedManager().orange, fruitsPosition[fruitCount]);
               
                break;
        }
        fruitCount++;
        SoundManagerForCollectFruits.sharedManager().PlayFruitCollectFX();
        if (fruitCount == fruitOnCartPosition.Length)
        {
            GameActions.sharedManager().gameOverType = GameActions.GameOverType.Win;
            GameActions.sharedManager().GameOver();
            MoveIt();
            fruitCount = 0;
            stackFilled++;
        }


    }

    public void MoveIt()
    {
        
        this.gameObject.transform.DOMove(new Vector3(-0.31f, -1.4f, -6.15f),1.5f);
        this.gameObject.transform.DORotate(new Vector3(0, 270, 0),1.5f);
    }

    private void CheckIfoodPositionExceed()
    {       
        Transform[] newCartPos = new Transform[1];
        newCartPos[0] = fruitOnCartPosition[fruitCount];
        newCartPos[0].position = new Vector3(fruitOnCartPosition[/*(stackFilled * fruitOnCartPosition.Length)+ */fruitCount].position.x,
                                                                fruitOnCartPosition[ fruitCount].position.y +
                                                                    (stackFilled==0 ? 0: .2f),
                                                                    fruitOnCartPosition[fruitCount].position.z);

        fruitsPosition.Add(newCartPos[0]);

       
       /* if (fruitCount >= fruitOnCartPosition.Length)
        {
            Transform[] newCartPos = new Transform[1];
            newCartPos[0].position = new Vector3(fruitsPosition[fruitCount - (fruitOnCartPosition.Length)].position.x,
                                                                    fruitsPosition[fruitCount - (fruitOnCartPosition.Length)].position.y + .2f,
                                                                        fruitsPosition[fruitCount - (fruitOnCartPosition.Length)].position.z);
            fruitsPosition.Add(newCartPos[0]);
            *//* fruitsPosition[fruitCount].rotation = new Quaternion(fruitsPosition[fruitCount - fruitOnCartPosition.Length].rotation.x,
                                                                     fruitsPosition[fruitCount - fruitOnCartPosition.Length].rotation.y + .2f,
                                                                         fruitsPosition[fruitCount - fruitOnCartPosition.Length].rotation.z, fruitsPosition[fruitCount - fruitOnCartPosition.Length].rotation.w);
 *//*
        }

        else
        {
            fruitsPosition.Add(fruitOnCartPosition[fruitCount]);
           // fruitsPosition[fruitCount].position = fruitOnCartPosition[fruitCount].position;
        }*/
        
    }

}
