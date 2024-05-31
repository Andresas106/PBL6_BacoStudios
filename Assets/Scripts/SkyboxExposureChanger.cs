using UnityEngine;

public class SkyboxExposureChanger : MonoBehaviour
{
    public float targetExposure = 1.5f;  // La exposición objetivo
    public float duration = 5.0f;  // El tiempo que tomará alcanzar la exposición objetivo
    public float resetDuration = 2.0f; // Tiempo para restablecer la exposición

    private float initialExposure = 0.5f;  // La exposición inicial
    private float timer = 0f;
    private bool changingExposure = false;
    private bool resettingExposure = false;

    void Start()
    {
        if (RenderSettings.skybox != null)
        {
            initialExposure = RenderSettings.skybox.GetFloat("_Exposure");
        }
    }

    void Update()
    {
        if (changingExposure)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            float newExposure = Mathf.Lerp(initialExposure, targetExposure, t);
            RenderSettings.skybox.SetFloat("_Exposure", newExposure);

            if (t >= 1.0f)
            {
                changingExposure = false;
            }
        }

        if (resettingExposure)
        {
            timer += Time.deltaTime;
            float t = timer / resetDuration;
            float newExposure = Mathf.Lerp(targetExposure, initialExposure, t);
            RenderSettings.skybox.SetFloat("_Exposure", newExposure);

            if (t >= 1.0f)
            {
                resettingExposure = false;
            }
        }
    }

    public void StartChangingExposure()
    {
        if (RenderSettings.skybox != null)
        {
            changingExposure = true;
            resettingExposure = false;
            timer = 0f;
            initialExposure = RenderSettings.skybox.GetFloat("_Exposure");
        }
    }

    public void ResetExposure()
    {
        if (RenderSettings.skybox != null)
        {
            resettingExposure = true;
            changingExposure = false;
            timer = 0f;
        }
    }
}
