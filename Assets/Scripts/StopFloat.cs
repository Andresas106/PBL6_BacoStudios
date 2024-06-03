using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFloat : MonoBehaviour
{


    [SerializeField] private GameObject floaat;


    public void Resume()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        floaat.GetComponent<RotationObject>().enabled = true;

    }
}
