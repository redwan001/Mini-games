using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] rooms;
    [HideInInspector]
    public int i;

    LuggageHandler lg;


    void Start()
    {
        RoomGenerator();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void RoomGenerator()
    {
        i = Random.Range(0, rooms.Length);
        rooms[i].gameObject.SetActive(true);


    }
}
