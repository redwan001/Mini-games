using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximitySensor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Fx;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("sdf");
    }




    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Fx != null)
            {
                
                Fx.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Fx != null)
            {
                Fx.gameObject.SetActive(false);
            }
        }
    }
}
