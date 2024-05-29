using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    FadeIN_OUT fade;
    private SkyboxExposureChanger skyboxExposureChanger;  // A�ade esto

    void Start()
    {
        fade = GetComponent<FadeIN_OUT>();
        skyboxExposureChanger = FindObjectOfType<SkyboxExposureChanger>();  // Encuentra el script SkyboxExposureChanger en la escena
    }

    public IEnumerator ChangeScene()
    {
        if (skyboxExposureChanger != null)
        {
            skyboxExposureChanger.ResetExposure();  // Restablece la exposici�n del skybox
        }

        fade.FadeIN();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Video_despedida1");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeScene());
        }
    }
}
