using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    private VideoPlayer videoPlayer; // Asigna el VideoPlayer en el Inspector

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            // Suscribirse al evento loopPointReached que se dispara cuando el video termina
            videoPlayer.loopPointReached += OnVideoEnd;
            Debug.Log("VideoPlayer encontrado y evento suscrito.");
        }
        else
        {
            Debug.LogError("VideoPlayer no encontrado!");
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("El video ha terminado.");
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Video_Intro")
        {
            // Cambiar de escena al terminar el video
            SceneManager.LoadScene("caratula1");
        }
        else if (scene.name == "Video_despedida1")
        {
            // Cambiar de escena al terminar el video
            SceneManager.LoadScene("caratula11");
        }
        else if (scene.name == "caratula1")
        {
            // Cambiar de escena al terminar el video
            SceneManager.LoadScene("Video_llegada1");
        }
        else if (scene.name == "Video_llegada1")
        {
            // Cambiar de escena al terminar el video
            SceneManager.LoadScene("Level1_FigaFlawas");
        }
        else if (scene.name == "caratula11")
        {
            // Cambiar de escena al terminar el video
            SceneManager.LoadScene("Video_llegada2");
        }
        else if (scene.name == "Video_llegada2")
        {
            // Cambiar de escena al terminar el video
            SceneManager.LoadScene("Level2_TheTyets");
        }
        else if (scene.name == "Level2_TheTyets")
        {
            // Cambiar de escena al terminar el video
            SceneManager.LoadScene("Video_despedida2");
        }
        else if (scene.name == "Video_despedida2")
        {
            // Cambiar de escena al terminar el video
            SceneManager.LoadScene("video_final");
        }
        else if (scene.name == "video_final")
        {
            // Busca el Canvas en la escena y actívalo al terminar el video
            Canvas finalCanvas = FindObjectOfType<Canvas>();
            if (finalCanvas != null)
            {
                finalCanvas.gameObject.SetActive(true);
                Debug.Log("Final Canvas activado.");
            }
            else
            {
                Debug.LogError("Final Canvas no encontrado en la escena!");
            }
        }
    }
}
