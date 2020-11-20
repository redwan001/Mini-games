using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Detection : MonoBehaviour
{
    int a;
    
    public Image progress;
    public float fillAmmmount;
    public GameObject canvas, panel, levelCom;
    public Button btnNextLvl;
    public Text fillText;
    public AudioClip sound;
    AudioSource m_MyAudioSource;


    bool played;
    private void Start()
    {
        canvas.SetActive(false);
        btnNextLvl.onClick.AddListener(() => StageManager.sharedManager().GotoNextLevel());
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
      
      float i = progress.fillAmount * 100;


        fillText.text = i.ToString ("0");   // "0" converts float to int
       
        if (progress.fillAmount == 1)
        {
            EnablePanel();
            enabled = false;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            progress.fillAmount += Time.deltaTime * fillAmmmount;
            canvas.SetActive(true);
          
       
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_MyAudioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            progress.fillAmount =  0;
            canvas.SetActive(false);
          
            m_MyAudioSource.Stop();
        }
    }



  
    void EnablePanel()
    {
        panel.gameObject.SetActive(true);
        if (!played)
        {
            Instantiate(levelCom, this.transform);
            played = true;
        }
    }
}



