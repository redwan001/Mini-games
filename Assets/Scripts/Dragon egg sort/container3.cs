using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//red one

public class container3 : MonoBehaviour
{
    public int countRed= 0;
    public GameObject eggPuff;
    private string cart3 = "Cart3Item";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(cart3))
        {
            GameManagerforSortingFruits.sharedManager().AddFruits(cart3, 1);
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
        if (collision.gameObject.CompareTag(cart3))
        {
            GameManagerforSortingFruits.sharedManager().DeductFruits(cart3, 1);
            countRed--;
        }
    }
}
