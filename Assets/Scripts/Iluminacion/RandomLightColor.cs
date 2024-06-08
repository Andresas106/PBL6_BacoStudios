using System.Collections;
using UnityEngine;

public class RandomLightColor : MonoBehaviour
{
    private Light pointLight;
    private Color targetColor;
    private float duration = 5f; // Tiempo en segundos para cambiar de color
    private float timer = 0f;

    void Start()
    {
        // Obtiene el componente Light del GameObject
        pointLight = GetComponent<Light>();
        // Establece un color inicial aleatorio
        targetColor = new Color(Random.value, Random.value, Random.value);
    }

    void Update()
    {
        // Incrementa el temporizador en el tiempo que ha pasado desde el último frame
        timer += Time.deltaTime;

        // Interpola el color de la luz hacia el color objetivo
        pointLight.color = Color.Lerp(pointLight.color, targetColor, timer / duration);

        // Si el temporizador supera la duración, reinícialo y selecciona un nuevo color objetivo
        if (timer > duration)
        {
            timer = 0f;
            targetColor = new Color(Random.value, Random.value, Random.value);
        }
    }
}
