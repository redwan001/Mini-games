using UnityEngine;

public class TreeDetection : MonoBehaviour
{

    private Quaternion currentRotation;
    private Vector3 currentPosition;
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        currentRotation = Quaternion.Euler(transform.localEulerAngles.x, this.gameObject.transform.localEulerAngles.y, this.gameObject.transform.localEulerAngles.z);

        // Debug.LogError(GameActions.sharedManager().player.transform.localPosition);
        Quaternion.Slerp(currentRotation, (GameActions.sharedManager().player.transform.localPosition.x > 15 &&
                        GameActions.sharedManager().player.transform.localPosition.x < 25) ? Quaternion.Euler(currentRotation.x, currentRotation.y+1, 0)
                        : currentRotation, 1);
    }
}
