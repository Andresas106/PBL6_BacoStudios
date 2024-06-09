using UnityEngine;

public class RandomSpotlightMovement : MonoBehaviour
{
    public Light spotLight; // La luz spot que queremos mover
    public float angleRange = 15f; // Rango de ángulos en grados
    public float moveInterval = 1f; // Intervalo de tiempo entre movimientos

    private Vector3 initialRotation; // Rotación inicial de la luz spot

    void Start()
    {
        if (spotLight == null)
        {
            spotLight = GetComponent<Light>();
        }

        if (spotLight == null || spotLight.type != LightType.Spot)
        {
            Debug.LogError("No se encontró una luz tipo Spot en el objeto.");
            enabled = false;
            return;
        }

        initialRotation = spotLight.transform.eulerAngles;
        InvokeRepeating(nameof(MoveSpotLight), 0f, moveInterval);
    }

    void MoveSpotLight()
    {
        // Generar ángulos aleatorios dentro del rango especificado
        float randomX = Random.Range(-angleRange, angleRange);
        float randomY = Random.Range(-angleRange, angleRange);

        // Aplicar los ángulos aleatorios a la rotación inicial
        Vector3 newRotation = initialRotation + new Vector3(randomX, randomY, 0f);

        // Asignar la nueva rotación a la luz spot
        spotLight.transform.rotation = Quaternion.Euler(newRotation);
    }
}
