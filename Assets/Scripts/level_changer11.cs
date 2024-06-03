using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_changer11 : MonoBehaviour
{
    private SkyboxExposureChanger skyboxExposureChanger;

    void Start()
    {
        skyboxExposureChanger = FindObjectOfType<SkyboxExposureChanger>();
        if (skyboxExposureChanger == null)
        {
            Debug.LogWarning("SkyboxExposureChanger component not found in the scene!");
        }
    }

    public IEnumerator ChangeScene()
    {
        if (skyboxExposureChanger != null)
        {
            skyboxExposureChanger.ResetExposure();  // Restablece la exposición del skybox
        }

        yield return new WaitForSeconds(1); // Tiempo de espera antes de cambiar la escena
        SceneManager.LoadScene("Video_despedida2");
        Debug.Log("Scene changed to Video_despedida2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone");
            StartCoroutine(ChangeScene());
        }
    }
}
