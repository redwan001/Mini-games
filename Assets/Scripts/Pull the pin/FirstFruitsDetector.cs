using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstFruitsDetector : MonoBehaviour
{
    public int NoOfApples;
    public GameObject Player1;



    public ParticleSystem pr, angryEmo;
    bool particleSystemPlayed = false;
    public GameObject gameOverPanel;
    bool angryEmoplayed = false;
    public bool gameOver;
    public bool firstFruitIn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NoOfApples > 12)
        {
            
            firstFruitIn = true;
            if (!particleSystemPlayed)
            {
                pr.Play();
                particleSystemPlayed = true;
            }
            Invoke("WinAnim", .5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
            NoOfApples++;
        else
        {
            gameOver = true;
            if (!angryEmoplayed)
            {
               angryEmo.Play();
                angryEmoplayed = true;
            }
            print("melons detected");
            FindObjectOfType<SecondFruitDetector>().Player2.GetComponent<Animator>().SetTrigger("Attack");

        }
    }


    void WinAnim()
    {
       Player1.GetComponent<Animator>().SetTrigger("Walk");
    }

}
