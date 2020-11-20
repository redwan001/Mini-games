using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ptpManager : MonoBehaviour
{
    public GameObject gameOverPanel, winPanel , levelComplete;
    bool played;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        if (FindObjectOfType<FirstFruitsDetector>().firstFruitIn && FindObjectOfType<SecondFruitDetector>().SecondndFruitIn)
        {

            Invoke("WinPanel", 3);
            Invoke("LoadNextScene", 4);
        }

        if (FindObjectOfType<FirstFruitsDetector>().gameOver || FindObjectOfType<SecondFruitDetector>().gameOver)
        {
            Invoke("GameOverPanel", 3);
            Invoke("Reset", 4);
        }
    }


    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (SceneManager.GetActiveScene().buildIndex == 6  && (FindObjectOfType<FirstFruitsDetector>().firstFruitIn && FindObjectOfType<SecondFruitDetector>().SecondndFruitIn))
        {
            SceneManager.LoadScene("pickuP");
        }
    }
    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }



    void WinPanel ()
    {
        winPanel.SetActive(true);
        if (!played)
        {
            Instantiate(levelComplete, transform.position, Quaternion.identity);
            played = true;
        }




    }
}
