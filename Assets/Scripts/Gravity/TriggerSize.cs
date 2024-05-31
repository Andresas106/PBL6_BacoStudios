using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSize : MonoBehaviour
{
    private CapsuleCollider myCollider;
    private float originalSize;
    private Vector3 originalCenter;

    public float height = 0.4f;
    public float centerC = 0.04f;
        

    void Start()
    {
        myCollider = GetComponent<CapsuleCollider>();
        originalSize = myCollider.height;
        originalCenter = myCollider.center;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(FirstWaitTime());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SecondWaitTime());
        }
    }


    IEnumerator FirstWaitTime()
    {
        yield return new WaitForSeconds(2);

        myCollider.height = height;
        Vector3 center = myCollider.center;
        center.y = centerC;
        myCollider.center = center;

    }

    IEnumerator SecondWaitTime()
    {
        yield return new WaitForSeconds(2);

        myCollider.height = originalSize;
        myCollider.center = originalCenter;
    }
}
