using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaling : MonoBehaviour
{
    public float tasrgetScale , speed;
    public int Count;

    private void Start()
    {
        StartCoroutine(ScaleOverTime(1));
    }

   


    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = this.transform.localScale;
        Vector3 destinationScale = new Vector3(tasrgetScale, tasrgetScale, tasrgetScale);

        float currentTime = 0.0f;

        do
        {
            this.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time * speed);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

       
    }

    IEnumerator DeScaleOverTime(float time)
    {
        Vector3 originalScale = this.transform.localScale;
        Vector3 destinationScale = new Vector3(.001f, .001f, .001f);

        float currentTime = 0.0f;

        do
        {
            this.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time * 4.5f);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        Destroy(this.gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cleaner") && Input.GetMouseButton(0))
        {
            print("----");
            StartCoroutine(DeScaleOverTime(1));


            Count += 1;
        }
    }


}
