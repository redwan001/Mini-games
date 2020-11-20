using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutter : MonoBehaviour
{
    public GameObject CrossEffect , cutSound;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit , 10000) && Input.GetMouseButton(0))
        {
            if (hit.collider.tag == "Rope")
            {
                GameObject effect =  Instantiate(CrossEffect, hit.collider.gameObject.transform.position, Quaternion.identity) as GameObject;
                GameObject sound = Instantiate(cutSound, transform.position, Quaternion.identity) as GameObject;
                Destroy(hit.collider.gameObject);
                Destroy(effect, .2f);
                Destroy(sound, 1);
            }


        }
    }

}
