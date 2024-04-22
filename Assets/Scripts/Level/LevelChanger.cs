using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    FadeIN_OUT fade;

    void Start()
    {
        fade = GetComponent<FadeIN_OUT>();
    }

    public IEnumerator ChangeScene()
    {
        fade.FadeIN();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MenuMain");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeScene());
        }
    }
}
