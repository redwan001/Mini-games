
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RopeDetection : MonoBehaviour
{
    public int count;
    public GameObject winPanel, puff, levelComplete ;
    public GameObject[] impactSounds;
    public Button btnNextLvl;

    bool played;
    void Start()
    {
        btnNextLvl.onClick.AddListener(() =>StageManager.sharedManager().GotoNextLevel());
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= 18)
        {
            EnableWinPanel();
            enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Rope"))
        {
            Destroy(collision.gameObject);


        }

        if(collision.gameObject.CompareTag("Melons"))
        {
            count += 1;
            Instantiate(puff, collision.transform.position, Quaternion.identity);
            GameObject impactSound = Instantiate(impactSounds[Random.Range(0,3)], collision.transform.position, Quaternion.identity) as GameObject;
            Destroy(impactSound, 1);
        }
    }

    void LoadNewLevel()
    {
        SceneManager.LoadScene("egg");
    }
    void EnableWinPanel()
    {
        winPanel.SetActive(true);

        if(!played)
        {
            Instantiate(levelComplete, transform);
            played = true;
        }

    }
}
