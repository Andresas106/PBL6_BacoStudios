using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class creditos_finales : MonoBehaviour
{
    private VideoPlayer videoPlayer; // Asigna el VideoPlayer en el Inspector
    public Canvas finalCanvas; // Asigna el Canvas en el Inspector
    private bool videoStarted = false;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            videoPlayer.started += OnVideoStarted;
            videoPlayer.loopPointReached += OnVideoEnd;
        }
        else
        {
            Debug.LogError("VideoPlayer no encontrado!");
        }

        if (finalCanvas != null)
        {
            finalCanvas.gameObject.SetActive(false); // Asegúrate de que el Canvas esté desactivado al inicio
        }
    }

    void OnVideoStarted(VideoPlayer vp)
    {
        videoStarted = true;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (!videoStarted) return; // Evita que se ejecute si el video aún no ha comenzado

        // Activar el Canvas al terminar el video
        if (finalCanvas != null)
        {
            finalCanvas.gameObject.SetActive(true);
            Invoke("LoadNextScene", 10f); // Esperar 10 segundos antes de cambiar de escena
        }
        else
        {
            Debug.LogError("Final Canvas no asignado!");
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("MenuMain"); // Cambia "NextSceneName" al nombre de la siguiente escena
    }
}
