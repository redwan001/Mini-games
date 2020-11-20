using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float speed = 10;


    Vector3 Vec;
    
    void Start()
    {

    }

    // Update is called once per frame  
    void Update()
    {

       // Vec = transform.localPosition;
//
      //  Vec.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
       // transform.localPosition = Vec;
    }

    public void GoUp()
    {
        Vec = transform.localPosition;       
        Vec.y +=  Time.deltaTime * speed;
        transform.localPosition = Vec;
    }
    public void GoDown()
    {
     
    
        Vec = transform.localPosition;
        Vec.y -= Time.deltaTime * speed;
        transform.localPosition = Vec;
    
   }
}