using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageSpawner : MonoBehaviour
{

    public GameObject[] luggages;

    void Start()
    {
        SpawnRandomLuggage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomLuggage()
    {
        int i = Random.Range(0, luggages.Length);
        luggages[i].gameObject.SetActive(true);
    }
}
