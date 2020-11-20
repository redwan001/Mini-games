using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] products;


    void Start()
    {
        SpawnRandomProducts();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnRandomProducts()
    {
        int i = Random.Range(0, products.Length);
        Instantiate(products[i] , this.transform.position, Quaternion.identity);
    }



    void Spwan()
    {
        for(int i = 0; i <= 4; i ++)
        {

        }
    }
}
