using UnityEngine;
using DG.Tweening;

public class MeterController : MonoBehaviour
{
    public RectTransform meterbar;
    public float meterstatus;
    public int colorPicker;
    Sequence mySequence;
    // Start is called before the first frame update
    void Start()
    {

        mySequence = DOTween.Sequence();
        TweenMeter();
    }

    public void TweenMeter()
    {
        mySequence.Play();
        mySequence.Append(meterbar.transform.DOLocalMoveX(390, 1.5f)/*.OnComplete(()=>
       meterbar.transform.DORotate(new Vector3(0, 0, 85), 1f))*/).SetLoops(-1, LoopType.Yoyo);       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Manager.sharedManager().isGameStarted)
            return;
        else
        {
            
           
            meterstatus = meterbar.GetComponent<RectTransform>().localPosition.x;
          //  meterstatus = (meterstatus >= 270) ? meterstatus - 360 : meterstatus;

            if (Input.GetMouseButtonDown(0))
            {
                CheckMeterStatus();
            }
        }
        
    }

    public void CheckMeterStatus()
    {
        mySequence.Pause();
        
        colorPicker = (meterstatus >= -100 && meterstatus <= 100) ? 1 : ((meterstatus >= 100 && meterstatus <= 150)
                                                                        || (meterstatus <= -100 && meterstatus >= -150)) ? 2 : 3;

        ShakeTree();
    }

    public void ShakeTree()
    {
        GameActions.sharedManager().ShakeTree();
    }
}
