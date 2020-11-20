using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerforSortingFruits : MonoBehaviour
{
    public static GameManagerforSortingFruits instance;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject inGamePanel;
    public Image timeScale;
    private float time = 30.0f;
    private bool hasTaskPassed;
    public Button NextLevel;
    public Button btnRetry;
    public GameObject controllers;
    int cart1;
    int cart2;
    int cart3;
    int cart4;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    void Start()
    {
        
        
    }

    public static GameManagerforSortingFruits sharedManager()
    {
        return instance;
    }

    public void AddFruits(string name, int amount)
    {
       switch(name)
        {
            case "Cart1Item":
                cart1 += amount;
                break;
            case "Cart2Item":
                cart2 += amount;
                break;
            case "Cart3Item":
                cart3 += amount;
                break;
            case "Cart4Item":
                cart4 += amount;
                break;
        }
        if(cart1 == 2 && cart2 ==2 && cart3 == 2 && cart4 == 2)
        {
            hasTaskPassed = true;
            WinrPanel();
        }
    }

    public void DeductFruits(string name,  int amount)
    {

        switch (name)
        {
            case "Cart1Item":
                cart1 -= amount;
                break;
            case "Cart2Item":
                cart2 -= amount;
                break;
            case "Cart3Item":
                cart3 -= amount;
                break;
            case "Cart4Item":
                cart4 -= amount;
                break;
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (hasTaskPassed) return;
        else
        {          
            if (timeScale.fillAmount == 0)
            {
                if (!hasTaskPassed)
                {
                    GameLose();
                    enabled = false;
                }

            }
            time -= Time.deltaTime;
            timeScale.fillAmount -= 1 / time * Time.deltaTime;
        }
        
    }

    void WinrPanel()
    {
        SoundManagerForSort.sharedManager().PlayWinFX();
        inGamePanel.SetActive(false);
        NextLevel.onClick.AddListener(() => StageManager.sharedManager().GotoNextLevel());
        WinPanel.SetActive(true);
        Destroy(controllers);

    }

    void GameLose()
    {
        SoundManagerForSort.sharedManager().PlayLoseFX();
        inGamePanel.SetActive(false);
        btnRetry.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        LosePanel.SetActive(true);
        controllers.SetActive(false);
    }
   /* private void Reset()
    {
        SceneManager.LoadScene("Dragon eats");
    }*/
}
