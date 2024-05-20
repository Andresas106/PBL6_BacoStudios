using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Asigna el VideoPlayer en el Inspector
    public string Level1_FigaFlawas; // Nombre de la escena a cargar

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
        }
        else
        {
            //Debug.LogError("VideoPlayer no encontrado!");
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Cambiar de escena al terminar el video
        SceneManager.LoadScene("Level1_FigaFlawas");
    }
}
