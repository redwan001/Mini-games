using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject suds, main, a, b , c , spray ;
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


        //SudMaker.gameObject.SetActive(false);
        //cleaner.gameObject.SetActive(true);
        //dirt.gameObject.SetActive(false);
        if (count >= 400)
        {
            main.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
           a.gameObject.SetActive(false);
            b.gameObject.SetActive(false);
            c.gameObject.SetActive(true);
            Invoke("sprays", 2);
            spray. gameObject.SetActive(false);
        }
            if (!played)
            {
                // pr.Emit(10);
                played = true;


            }

        
        
        RaycastHit objectHit;
        // Shoot raycast
        if (Physics.Raycast(transform.position, -transform.forward, out objectHit, 50))
        {
            Debug.Log("Raycast hitted to: " + objectHit.collider);
            if (objectHit.collider.gameObject.CompareTag("Ground") && Input.GetMouseButton(0) && !objectHit.collider.gameObject.CompareTag("suds"))
            {
                Instantiate(suds, objectHit.point, Quaternion.Euler(-90, 0, 0));
                count += 1;
            }
        }

    }

    void sprays()
    {
        cleaner.gameObject.SetActive(true);
    }
}

