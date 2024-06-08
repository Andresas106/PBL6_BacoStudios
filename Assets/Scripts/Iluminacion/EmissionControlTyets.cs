using UnityEngine;

public class EmissionControlTyets : MonoBehaviour
{
    public Renderer targetRenderer;  // El renderer del objeto que tiene el material con la emisi�n
    public Color emissionColor = Color.white;  // El color de la emisi�n
    private Material targetMaterial;
    private Color originalEmissionColor;
    private bool isInsideTrigger = false;

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
            if (targetMaterial != null)
            {
                // Encender la emisi�n
                targetMaterial.EnableKeyword("_EMISSION");
                targetMaterial.SetColor("_EmissionColor", emissionColor);
                isInsideTrigger = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verificar la etiqueta del objeto
        {
            if (targetMaterial != null)
            {
                // Apagar la emisi�n solo si realmente se sale del trigger
                if (isInsideTrigger)
                {
                    targetMaterial.SetColor("_EmissionColor", originalEmissionColor);
                    targetMaterial.DisableKeyword("_EMISSION");
                    isInsideTrigger = false;
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && targetMaterial != null && !isInsideTrigger) // Verificar la etiqueta del objeto
        {
            // Asegurarse de que la emisi�n sigue encendida mientras est� dentro del trigger
            targetMaterial.EnableKeyword("_EMISSION");
            targetMaterial.SetColor("_EmissionColor", emissionColor);
            isInsideTrigger = true;
        }
    }
}
