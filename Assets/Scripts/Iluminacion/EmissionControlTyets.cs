using UnityEngine;

public class EmissionControlTyets : MonoBehaviour
{
    public Renderer targetRenderer;  // El renderer del objeto que tiene el material con la emisi�n
    public Color emissionColor = Color.white;  // El color de la emisi�n
    private Material targetMaterial;
    private Color originalEmissionColor;
    private int playerCount = 0;  // Contador para objetos con la etiqueta "Player"

    void Start()
    {
        if (targetRenderer == null)
        {
            targetRenderer = GetComponent<Renderer>();
        }

        if (targetRenderer != null)
        {
            targetMaterial = targetRenderer.material;

            // Guardar el color de emisi�n original
            if (targetMaterial.IsKeywordEnabled("_EMISSION"))
            {
                originalEmissionColor = targetMaterial.GetColor("_EmissionColor");
            }
            else
            {
                originalEmissionColor = Color.black;
            }
        }
        else
        {
            Debug.LogError("Renderer no encontrado en el objeto.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verificar la etiqueta del objeto
        {
            playerCount++;

            if (targetMaterial != null)
            {
                // Encender la emisi�n
                targetMaterial.EnableKeyword("_EMISSION");
                targetMaterial.SetColor("_EmissionColor", emissionColor);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verificar la etiqueta del objeto
        {
            playerCount--;

            if (targetMaterial != null && playerCount <= 0)
            {
                // Apagar la emisi�n solo si realmente se sale del trigger
                targetMaterial.SetColor("_EmissionColor", originalEmissionColor);
                targetMaterial.DisableKeyword("_EMISSION");
                playerCount = 0;  // Asegurarse de que el contador no sea negativo
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && targetMaterial != null) // Verificar la etiqueta del objeto
        {
            // Asegurarse de que la emisi�n sigue encendida mientras est� dentro del trigger
            targetMaterial.EnableKeyword("_EMISSION");
            targetMaterial.SetColor("_EmissionColor", emissionColor);
        }
    }
}
