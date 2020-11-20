using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//White one 
public class container2 : MonoBehaviour
{
    public int countWhite = 0;
    public GameObject eggPuff;
    private string cart2 = "Cart2Item";

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(cart2))
        {
            GameManagerforSortingFruits.sharedManager().AddFruits(cart2, 1);
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
        if (collision.gameObject.CompareTag(cart2))
        {
            GameManagerforSortingFruits.sharedManager().DeductFruits(cart2, 1);
            countWhite--;
        }
    }
}


