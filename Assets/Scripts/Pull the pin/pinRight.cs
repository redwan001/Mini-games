
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinRight : MonoBehaviour
{
    public GameObject tapSound;
    public float speed;
    public bool clicked;
    bool played;
    void Start()
    {
       
    }

    // Update is called once per frame
  
        void Update () {
           RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0))
                {
                    if (hit.collider.tag == "Pin") { 
                 
                   clicked = true;
                if (!played)
                {

                    GameObject sound = Instantiate(tapSound, transform.position, Quaternion.identity) as GameObject;
                    Destroy(sound, 1);
                    played = true;
                }
            }
              
                
                }
                if(clicked)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        }
}
