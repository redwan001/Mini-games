using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LuggageHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform luggagePos;
    public GameObject luggagePickupSound, levelCompleted;
    public int count;

    bool playedl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
            if (FindObjectOfType<LevelManager>().i == 0 || FindObjectOfType<LevelManager>().i == 2)
        {
            if (count == 8)
            {
                print("win big");
                if (!playedl)
                { 
                    GameObject g = Instantiate(levelCompleted, transform.position, Quaternion.identity);
                Destroy(g, 1f);
                    playedl = true;
            }
                Invoke("Reset", 1.5f);
            }
        }
            else
        {
            if(count == 11)
            {
                print("win small");
                if (!playedl)
                {
                    GameObject g = Instantiate(levelCompleted, transform.position, Quaternion.identity);
                    Destroy(g, 1f);
                    playedl = true;
                }
                Invoke("Reset", 1.5f);
            }
        }

        
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Luggage"))
        {
            
            collision.transform.parent = this.transform;
            //object1 is now the child of object2
            collision.gameObject.transform.position = luggagePos.position;
            collision.transform.rotation = luggagePos.transform.rotation;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.transform.GetChild(1).gameObject.SetActive(false);
            collision.transform.GetChild(0).gameObject.SetActive(false);
            PickupSound();
            count++;
            luggagePos.position = new Vector3(luggagePos.transform.position.x, luggagePos.transform.position.y + 1 ,luggagePos.transform.position.z);
            
        }
    }


    void PickupSound()
    {
        GameObject g = Instantiate(luggagePickupSound, transform.position, Quaternion.identity);
        Destroy(g, 1f);
    }



    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
