
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTouch : MonoBehaviour
{
   
    Animator anim;
    public Animator move ;
    public int randomBandit;
    public GameObject banditClone;
    bool played;
    void Start()
    {
        anim = GetComponent<Animator>();
     
    }

    // Update is called once per frame
    void Update()
    {
       
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)
            && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Instantiate(Resources.Load("Prefabs/fx/poof") as GameObject , hit.collider.transform.position, Quaternion.identity);
                anim.SetTrigger("Walk");
                move.Play("flyy");
                GameObject.Find("EGG1").GetComponent<Animator>().Play("EGGS1");
                RandomSound();
            }

            if (hit.collider.gameObject.tag == "Player1")
            {
                Instantiate(Resources.Load("Prefabs/fx/poof") as GameObject, hit.collider.transform.position, Quaternion.identity);
                anim.SetTrigger("walk");
                move.Play("flyy2");
                GameObject.Find("EGG2").GetComponent<Animator>().Play("egg");
                RandomSound();

            }
            if (hit.collider.gameObject.tag == "Player3")
            {
                Instantiate(Resources.Load("Prefabs/fx/poof") as GameObject, hit.collider.transform.position, Quaternion.identity);
                anim.SetTrigger("walk3");
                move.Play("fly3");
                GameObject.Find("EGG3").GetComponent<Animator>().Play("egg3");
                RandomSound();

            }
            if (hit.collider.gameObject.tag == "Player4")
            {
                Instantiate(Resources.Load("Prefabs/fx/poof") as GameObject, hit.collider.transform.position, Quaternion.identity);
                anim.SetTrigger("walk4");
                move.Play("fly4");
                GameObject.Find("EGG4").GetComponent<Animator>().Play("egg4");
                RandomSound();

            }
        }
               


   
        


    }


    void RandomSound()
    {
        randomBandit = Random.Range(1, 4); //Random bandit 1-5 (6 is excluded)

        banditClone = Resources.Load("Prefabs/egg take/sounds/sound1 " + randomBandit) as GameObject;
        Debug.Log(banditClone);
        banditClone = Instantiate(banditClone, transform.position, transform.rotation) as GameObject;

        Destroy(banditClone, 2);
    }
}
