using UnityEngine;

public class ScannerController : MonoBehaviour
{

    private Vector3 mouseCurrentPosition;
    private Vector3 mouseStartPosition;
    private Vector3 distance;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseCurrentPosition = Input.mousePosition;
        
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            distance = (mouseCurrentPosition - mouseStartPosition).normalized;
            this.gameObject.transform.position = Vector3.Lerp (this.transform.localPosition, new Vector3(distance.x, distance.y, this.transform.localPosition.z), 2 * Time.smoothDeltaTime);
            if (Physics.Raycast(this.transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(this.gameObject.transform.position, transform.forward * 100, Color.red);
                if (hit.collider.CompareTag("Pear"))
                {
                    Debug.LogError("Entered");   
                }
               
            }
        }
    }
}
