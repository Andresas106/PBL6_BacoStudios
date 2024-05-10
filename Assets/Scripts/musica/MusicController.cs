using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource[] canciones;  // Array de canciones
    [SerializeField] private int cancionActiva = 0;  // Índice de la canción activa

    void Start()
    {
        // Iniciamos todas las canciones en mute
        foreach (var cancion in canciones)
        {
            cancion.mute = true;
        }
    }

    public void PlaySong(int songIndex)
    {
        if (songIndex < 0 || songIndex >= canciones.Length)
        {
            Debug.LogError("Índice de canción fuera de rango");
            return;
        }

        // Silenciar todas las canciones
        foreach (var cancion in canciones)
        {
            cancion.mute = true;
            cancion.Stop();
        }

        // Reproducir la canción indicada
        cancionActiva = songIndex;
        canciones[cancionActiva].mute = false;
        canciones[cancionActiva].Play();
    }
}
