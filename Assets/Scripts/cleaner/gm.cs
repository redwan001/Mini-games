using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gm : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player, water , levelCompleteSound;
    public ParticleSystem pr , pr1 ;
    bool played = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
            pr.Play();

        if (GameObject.Find("Suds(Clone)") != null)
        {
            print("it exists ");
        }
            else
        {
            pr.Stop();
            pr.gameObject.SetActive(false);
            print("it is noit");
            if (!played)
            {
                pr1.Emit(10);
                GameObject sound = Instantiate(levelCompleteSound, transform.position, Quaternion.identity);
                Destroy(sound, 3);
                played = true;
             

            }
        
            player.gameObject.SetActive(false);

            water.GetComponent<Animator>().Play("water");
            Invoke("Reset", 6f);
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
