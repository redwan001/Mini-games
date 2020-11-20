using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public List<GameObject> stages;
    private GameObject myCurrentStageLevel;
    GameObject go;
    int stageNo;
    int MaxStage;
    string stage = "stage";
    // Start is called before the first frame update

    private void Awake()
    {
        if (!instance) instance = this;
        MaxStage = stages.Count;
    }

    public static StageManager sharedManager()
    {
        return instance;
    }
    void Start()
    {
        stageNo = PlayerPrefs.GetInt(stage, 0);
        AssignValues();
        
    }

    void AssignValues()
    {
        go = new GameObject("Level 10" + stageNo);
        go.transform.parent = this.gameObject.transform;
       // Instantiate(go, this.transform);
        myCurrentStageLevel = Instantiate(stages[stageNo], go.transform);
        myCurrentStageLevel.SetActive(true);
    }

    public void GotoNextLevel()
    {
        stageNo++;
        if(stageNo == MaxStage)
        {
            stageNo = Random.Range(0, MaxStage - 1);
        }
        PlayerPrefs.SetInt(stage, stageNo);
        DestroyPreviousStage();
        AssignValues();
        
    }

    public void DestroyPreviousStage()
    {
        Destroy(go);
    }
}
