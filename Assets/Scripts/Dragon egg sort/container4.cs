using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// blue one 
public class container4 : MonoBehaviour
{
    public int countBlue = 0;
    public GameObject eggPuff;
    
    private string cart4 = "Cart4Item";
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(cart4))
        {
            GameManagerforSortingFruits.sharedManager().AddFruits(cart4, 1);
            Instantiate(eggPuff, collision.transform.position, Quaternion.identity);
            SoundManagerForSort.sharedManager().PlayPerfectDropFX();

        }
        else
        {
            SoundManagerForSort.sharedManager().PlayImperfectDropFX();


        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(cart4))
        {
            GameManagerforSortingFruits.sharedManager().DeductFruits(cart4, 1);
            countBlue--;
        }
    }
}
