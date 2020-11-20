using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SecondFruitDetector : MonoBehaviour
{
    public int  NoOfMelons , NoOfPumpkins , NoOfStawberry, NoOfBanana;
    public GameObject Player2;


    public ParticleSystem pr, angryEmo;
    bool particleSystemPlayed = false;

    bool angryEmoplayed = false;
    public bool SecondndFruitIn;
    public bool gameOver;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NoOfMelons > 10)
        {
            SecondndFruitIn = true;
            if (!particleSystemPlayed )
            {
                pr.Play();
                particleSystemPlayed = true;
            }

            Invoke("WinAnim", .5f);
           
        }
        if(NoOfPumpkins > 10)
        {
            SecondndFruitIn = true;
            if (!particleSystemPlayed)
            {
                pr.Play();
                particleSystemPlayed = true;
            }
            Invoke("WinAnim", .5f);
           
        }
        if (NoOfStawberry > 10)
        {
            SecondndFruitIn = true;
            if (!particleSystemPlayed)
            {
                pr.Play();
                particleSystemPlayed = true;
            }
            Invoke("WinAnim", .5f);

        }
        if (NoOfBanana > 10)
        {
            SecondndFruitIn = true;
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


        if (other.gameObject.CompareTag("Melons"))
        {
            NoOfMelons++;
        }
        else if (other.gameObject.CompareTag("Pumpkins"))
            NoOfPumpkins++;

        else if (other.gameObject.CompareTag("Stawberry"))
            NoOfStawberry++;

        else if (other.gameObject.CompareTag("Banana"))
            NoOfBanana++;

        else
        {
            gameOver = true;
            if (!angryEmoplayed )
            {
                angryEmo.Play();
                angryEmoplayed = true;
            }
            print("melons detected");
            FindObjectOfType<FirstFruitsDetector>().Player1.GetComponent<Animator>().SetTrigger("Attack");
        }

    }

    void WinAnim()
    {
        Player2.GetComponent<Animator>().SetTrigger("Walk");
    }

}