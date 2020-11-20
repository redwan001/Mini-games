using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCan : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 originalPositionValue;
    private Quaternion originalRotationValue;
    private Vector3 screenPoint;
    private Vector3 offset;

    public GameObject player;
    private void Start()
    {
        originalRotationValue = player.transform.rotation;
        originalPositionValue = player.transform.position;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

        }
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(player.transform.position);

        offset = player.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }


}
