using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// the green oneeee 
public class container1 : MonoBehaviour
{
    public int countGreen  = 0 ;
    public GameObject eggPuff;
    private string cart1 = "Cart1Item";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(cart1))
        {
            GameManagerforSortingFruits.sharedManager().AddFruits(cart1, 1);
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
        if (collision.gameObject.CompareTag(cart1))
        {
            GameManagerforSortingFruits.sharedManager().DeductFruits(cart1, 1);
            countGreen--;
        }
    }
}
