using UnityEngine;

public class OrbitAround : MonoBehaviour
{
    public Transform centerObject; // El objeto alrededor del cual girar�
    public float orbitSpeed = 10f; // Velocidad de �rbita
    public float selfRotationSpeed = 20f; // Velocidad de rotaci�n propia en el eje Y

    private bool IsPlayerIn = false;


    // Methods to be called by the child trigger component
    public void OnPlayerEnterTrigger()
    {
        IsPlayerIn = true;
    }

    public void OnPlayerExitTrigger()
    {
        IsPlayerIn = false;
    }

    void Update()
    {
        if(!IsPlayerIn)
        {
            // Calcula la posici�n relativa al centro
            Vector3 relativePos = transform.position - centerObject.position;

            // Calcula la rotaci�n orbital alrededor del centro
            Quaternion orbitRotation = Quaternion.Euler(0, orbitSpeed * Time.deltaTime, 0);

            // Aplica la rotaci�n orbital alrededor del centro
            relativePos = orbitRotation * relativePos;

            // Aplica la rotaci�n propia del objeto sobre su propio eje Y
            transform.RotateAround(centerObject.position, Vector3.up, selfRotationSpeed * Time.deltaTime);

            // Establece la nueva posici�n del objeto
            transform.position = centerObject.position + relativePos;
        }
    }
        
}