using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    [Header("All Panels")]
    public GameObject inGamePanel;

    public Button btnRestart;
    public Button tapToStart;
    public Animator inGamePanelAnim;
    [HideInInspector] public bool isGameStarted;
    [HideInInspector] public bool isGameOver;
    [Header("Fruit Prefabs")]
    public GameObject apples;
    public GameObject orange;
    public GameObject coconut;

    public TextMeshProUGUI txtBtnRestart;
    private WaitForSeconds wait = new WaitForSeconds(1.50f);
    // Start is called before the first frame update


    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    public static Manager sharedManager()
    {
        return instance;
    }
    void Start()
    {
        tapToStart.onClick.AddListener(() => StartGame());
        btnRestart.onClick.AddListener(() => Restart());
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        Camera.main.transform.DOMoveZ(-9.5f, 1);        
        inGamePanelAnim.enabled = true;
        Destroy(tapToStart.gameObject);
        isGameStarted = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
