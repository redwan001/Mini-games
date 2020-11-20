using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameActions : MonoBehaviour
{
    public enum GameOverType
    {
        None,
        Win,
        Lose
    }
    public GameOverType gameOverType;
    public static GameActions instance;
    public GameObject finishPos;
    [Header("For Fruit Collection")]
    public MeterController meterController;
    public GameObject[] Tree;
    public List<Rigidbody> fruitLists;
    public Animator fadeAnim;
    public GameObject CollectViewCamPosition;
    public GameObject PlayerCollector;
    public GameObject player;
    public GameObject foodCollectorPos;
    public TextMeshProUGUI txtInstruction;
    private Vector3 camPosition;
    private Quaternion camRotation;
    private WaitForSeconds wait = new WaitForSeconds(6.0f);
    private WaitForSeconds waitForCamPositionChange = new WaitForSeconds(1.10f);
    private WaitForSeconds waitForFade = new WaitForSeconds(1.5f);
    private WaitForSeconds cameraSlide = new WaitForSeconds(3.0f);
    [HideInInspector] public int treeType =0;
    [HideInInspector] public bool hasPlayerInitialized;
    public GameObject[] GameOverFx;
    public GameObject gameOverPanel;
    
    private void Awake()
    {
        if (!instance)
            instance = this;        
    }

    public static GameActions sharedManager()
    {
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        AddFruits();
        camPosition = CollectViewCamPosition.transform.position;
        camRotation = CollectViewCamPosition.transform.rotation;
    }
    public void AddFruits()
    {
        foreach (Transform rb in Tree[treeType].transform)
        {
            rb.gameObject.AddComponent<Rigidbody>();
            fruitLists.Add(rb.gameObject.GetComponent<Rigidbody>());
        }
        DisableFruitsGravity();
    }

    public void ShakeTree()
    {
        #region YOU DON"T WANNA SEE THAT WEIRED CODE

        switch(meterController.colorPicker)
        {
            case 1:
                #region Shake Hard
                Tree[treeType].transform.DORotate(new Vector3(0, 0, -5f), .4f).OnComplete(() =>
               Tree[treeType].transform.DORotate(new Vector3(0, 0, 5f), .2f).OnComplete(() =>
                    Tree[treeType].transform.DORotate(new Vector3(0, 0, -6f), .2f).OnComplete(() =>
                        Tree[treeType].transform.DORotate(new Vector3(0, 0, 6f), .09f).OnComplete(() =>
                            Tree[treeType].transform.DORotate(new Vector3(0, 0, -4f), .09f).OnComplete(() =>
                                Tree[treeType].transform.DORotate(new Vector3(0, 0, 4f), .09f).OnComplete(() =>
                                    Tree[treeType].transform.DORotate(new Vector3(0, 0, -5f), .1f).OnComplete(() =>
                                        Tree[treeType].transform.DORotate(new Vector3(0, 0, 5f), .1f).OnComplete(() =>
                                            Tree[treeType].transform.DORotate(new Vector3(0, 0, 0), .1f).OnComplete(() =>
                                                                            EnableFruitRb())))))))));
                #endregion
                break;

            case 2:
                #region Shake Mild                
                        Tree[treeType].transform.DORotate(new Vector3(0, 0, 6f), .09f).OnComplete(() =>
                            Tree[treeType].transform.DORotate(new Vector3(0, 0, -4f), .09f).OnComplete(() =>
                                Tree[treeType].transform.DORotate(new Vector3(0, 0, 4f), .09f).OnComplete(() =>
                                    Tree[treeType].transform.DORotate(new Vector3(0, 0, -5f), .1f).OnComplete(() =>
                                        Tree[treeType].transform.DORotate(new Vector3(0, 0, 5f), .1f).OnComplete(() =>
                                            Tree[treeType].transform.DORotate(new Vector3(0, 0, 0), .1f).OnComplete(() =>
                                                                            EnableFruitRb()))))));
                #endregion
                break;
            case 3:
                #region Shake twice
                Tree[treeType].transform.DORotate(new Vector3(0, 0, 4f), .09f).OnComplete(() =>
                                    Tree[treeType].transform.DORotate(new Vector3(0, 0, -5f), .1f).OnComplete(() =>
                                        Tree[treeType].transform.DORotate(new Vector3(0, 0, 5f), .1f).OnComplete(() =>
                                            Tree[treeType].transform.DORotate(new Vector3(0, 0, 0), .1f).OnComplete(() =>
                                                                            EnableFruitRb()))));
                #endregion
                break;


        }


        #endregion
    }
    public void DisableFruitsGravity()
    {
       
      for (int i = 0; i < fruitLists.Count; i++)
      {
          fruitLists[i].useGravity = false;
      }
        
        EnableMeterTween();
    }

    private void EnableMeterTween()
    {
        if(!Manager.sharedManager().isGameStarted && treeType >0)
        {
            
            Manager.sharedManager().isGameStarted = true;
            meterController.TweenMeter();
        }
            
    }
    public void EnableFruitRb()
    {
        switch (meterController.colorPicker)
        {
            case 1:
                for (int i = 0; i < fruitLists.Count; i++)
                {
                    fruitLists[i].useGravity = true;
                    
                }
                break;
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    fruitLists[i].useGravity = true;
                    
                }
                gameOverType = GameOverType.Lose;
                break;
            case 3:
                fruitLists[0].useGravity = true;
                gameOverType = GameOverType.Lose;
                break;
        }
        treeType++;
        Manager.sharedManager().isGameStarted = false;
        StartCoroutine(ChangeCamPosition());
    }

    public IEnumerator ChangeCamPosition()
    {

        if(gameOverType == GameOverType.Lose)
        {
            GameOver();
        }

        else
        {
            yield return cameraSlide;
            fruitLists.Clear();
            switch (treeType)
            {
                case 1:
                    Camera.main.transform.DOMoveX(5.3f, 1).OnComplete(() =>
                        AddFruits());
                    break;
                case 2:
                    Camera.main.transform.DOMoveX(-4.7f, .5f).OnComplete(() =>
                        AddFruits());
                    break;
                default:
                    StartCoroutine(CollectThemAll());
                    break;

            }
        }
       

    }


    public IEnumerator CollectThemAll()
    {
        

        yield return waitForFade;
        player =  Instantiate(PlayerCollector, foodCollectorPos.transform);
        player.SetActive(true);
        Camera.main.gameObject.AddComponent<TreeDetection>();
        fadeAnim.enabled = true;
        StartCoroutine(ChangePerspective());
        yield return wait;
       
        freezePosition();
    }

    public IEnumerator ChangePerspective()
    {
        yield return waitForCamPositionChange;
        txtInstruction.text = "Collect them All!";
        Camera.main.transform.position = camPosition;
        Camera.main.transform.rotation = camRotation;
        Manager.sharedManager().inGamePanelAnim.gameObject.transform.GetChild(1).gameObject.SetActive(false);

    }

    public void freezePosition()
    {       
        for (int i = 0; i < fruitLists.Count; i++)
        {
            if(fruitLists[i]!=null)
            {
                fruitLists[i].constraints = RigidbodyConstraints.FreezeAll;
            }
           
        }
    }
    // Update is called once per frame
    void Update()
    {
     
    }


    public void GameOver()
    {
        switch(gameOverType)
        {
            case GameOverType.Win:
                for (int i = 0; i < GameOverFx.Length; i++)
                {
                    GameOverFx[i].SetActive(true);
                }
                SoundManagerForCollectFruits.sharedManager().PlayWinFX();
                Manager.sharedManager().isGameStarted = false;
                Manager.sharedManager().isGameOver = true;
                gameOverPanel.SetActive(true);
                Manager.sharedManager().txtBtnRestart.text = "Next Level";
                Manager.sharedManager().btnRestart.onClick.AddListener(() => StageManager.sharedManager().GotoNextLevel());
                Manager.sharedManager().inGamePanel.SetActive(false);
                break;
            case GameOverType.Lose:
                SoundManagerForCollectFruits.sharedManager().PlayLoseFX();
                Manager.sharedManager().isGameStarted = false;
                Manager.sharedManager().isGameOver = true;
                gameOverPanel.SetActive(true);
                Manager.sharedManager().inGamePanel.SetActive(false);
                break;
        }

        

    }

}
