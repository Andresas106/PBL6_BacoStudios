using System.Diagnostics;
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
        }
        else
        {
            //Debug.LogError("VideoPlayer no encontrado!");
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Video_Intro")
        {
            // Cambiar de escena al terminar el video
            SceneManager.LoadScene("Level1_FigaFlawas");
        }
        else if(scene.name == "Video_despedida1")
        {
            // Cambiar de escena al terminar el video
            SceneManager.LoadScene("Level2_TheTyets");
        }
        

    }
}
