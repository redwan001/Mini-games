using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    private Vector3 mOffset;



    private float mZCoord;



    void OnMouseDown()

    {
     


        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        

        GetComponent<Rigidbody>().useGravity = false;
        // Store offset = gameobject world pos - mouse world pos

        mOffset = new Vector3(transform.position.x, 2.83f, transform.position.z) - GetMouseAsWorldPoint();

    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }

    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {

        transform.position = GetMouseAsWorldPoint() + mOffset  ;

    }

}