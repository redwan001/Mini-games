using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCart : MonoBehaviour
{
    public int apples;
    public GameObject FirstDrag;
    public ParticleSystem pr;
    bool particleSystemPlayed = false;

    private Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(apples > 20)
        {
           FirstDrag.GetComponent<Animator>().SetTrigger("Walk");
            if (!particleSystemPlayed)
            {
                pr.Play();
                particleSystemPlayed = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            apples++;
          
        }
    }


}
