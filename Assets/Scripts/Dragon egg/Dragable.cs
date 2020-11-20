using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragable : MonoBehaviour
{
    Vector3 startPos;
    Vector3 dist;
    public GameObject sound;
    bool isPlayed;
    void OnMouseDown()
    {
        startPos = Camera.main.WorldToScreenPoint(transform.position);
        dist = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, startPos.z));
      
        GetComponent<AudioSource>().Play();

 
    }

    private void OnMouseUp()
    {
        GetComponent<AudioSource>().Stop();
    }

    void OnMouseDrag()
    {
        Vector3 lastPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, startPos.z);
        transform.position = Camera.main.ScreenToWorldPoint(lastPos) + dist;
    }
  
}
