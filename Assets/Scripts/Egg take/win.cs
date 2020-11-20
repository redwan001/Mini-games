
using UnityEngine;
using UnityEngine.UI;
public class win : MonoBehaviour
{
    // Start is called before the first frame update
    public static win instance;
    public GameObject[] Player1;
    public GameObject[] Player2;
    public GameObject[] Player3;
    public GameObject[] Player4;
    public GameObject spark , panel ;
    public Text eggText;
    public GameObject PlayerPosition ,secondPosition , thirdPosition , forthPosition , levelCom;
    public AudioClip eggDropSound;
    public Button btnNextLvl;
    AudioSource audio;
    private int CurrentLevelNo;
    private int a , b , c;
    bool played;
    void Start()
    {
        btnNextLvl.onClick.AddListener(() => StageManager.sharedManager().GotoNextLevel());
        audio = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        if (!instance)
            instance = this;

        GenerateLevel();
    }

    private void GenerateLevel()
    {
        CurrentLevelNo = PlayerPrefs.GetInt("LevelNo", 0);

        Instantiate(Player1[Random.Range(0, 3)], PlayerPosition.transform);
        Instantiate(Player2[Random.Range(0, 3)], secondPosition.transform);
        Instantiate(Player3[Random.Range(0, 3)], thirdPosition.transform);
        Instantiate(Player4[Random.Range(0, 3)], forthPosition.transform);

        /*  Instantiate(Player1[Random.Range(0,3)], PlayerPosition.transform.position, Quaternion.identity);
          Instantiate(Player2[Random.Range(0, 3)], secondPosition.transform.position, Quaternion.identity);
          Instantiate(Player3[Random.Range(0, 3)], thirdPosition.transform.position, Quaternion.identity);
          Instantiate(Player4[Random.Range(0, 3)], forthPosition.transform.position, Quaternion.identity);*/
    }

    // Update is called once per frame
    void Update()
    {
        eggText.text = c.ToString();
        c = a + b;
        if (c == 18)
        {
            EnablePanel();
            enabled = false;
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("egg1"))
        {
            a++;
            Instantiate(spark, other.transform.position, Quaternion.identity);
            audio.clip = eggDropSound;

            audio.Play();
        }
        if (other.gameObject.CompareTag("egg2"))
        {
            b++;
            Instantiate(spark, other.transform.position, Quaternion.identity);
            audio.clip = eggDropSound;

            audio.Play();
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
