using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static manager instance;

    public GameObject[] EggTray;
    public GameObject spawnPoint , a;
    private int CurrentLevelNo;
    bool played;


    void Start()
    {

    }
    private void Update()
    {

    }
    private void OnEnable()
    {
        if (!instance)
            instance = this;

        GenerateLevel();
    }

    private void GenerateLevel()
    {
        CurrentLevelNo = PlayerPrefs.GetInt("LevelNo", 0);

        Instantiate(EggTray[Random.Range(0, 2)], spawnPoint.transform.position, Quaternion.identity);
        

    }
}
