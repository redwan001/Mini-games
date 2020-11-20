using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject suds;
    public int count;
    public GameObject SudMaker;
    public GameObject cleaner, dirt;
    public ParticleSystem pr;

    bool played = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(FindObjectOfType<scaling>().Count);
        if(count >= 140)
        {
            SudMaker.gameObject.SetActive(false);
            cleaner.gameObject.SetActive(true);
            dirt.gameObject.SetActive(false);
            if (!played)
            {
                pr.Emit(10);
                played = true;

               
            }
    
           
        }
        RaycastHit objectHit;
        // Shoot raycast
        if (Physics.Raycast(transform.position, -transform.forward, out objectHit, 50))
        {
           Debug.Log("Raycast hitted to: " + objectHit.collider);
            if (objectHit.collider.gameObject.CompareTag("Ground") && Input.GetMouseButton(0) && !objectHit.collider.gameObject.CompareTag("suds"))
            {
                Instantiate(suds, objectHit.point, Quaternion.identity);
                count += 1;
            }
        }

    }


}

