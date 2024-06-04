using System.Collections;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public AudioSource fuente;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        fuente.clip = clip;
    }

    // Update is called once per frame
    public void Reproducir()
    {
        fuente.Play();
    }
}
