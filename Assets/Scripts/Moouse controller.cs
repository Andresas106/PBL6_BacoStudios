using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookThirdPerson : MonoBehaviour
{
    public float mouseSensitivity = 150f;
    public Transform playerBody;
    float xRotation = 0;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}


/*public class CameraLookThirdPerson : MonoBehaviour
{
    public float mouseSensitivity = 150f;
    public Transform playerBody;
    public Vector3 offset = new Vector3(0, 1, -2); // Offset inicial de la cámara respecto al jugador

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Aplicar el offset inicial
        transform.position = playerBody.position + offset;
    }

    void Update()
    {
        // Rotación de la cámara
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX); // Rotar el cuerpo del jugador horizontalmente

        // Rotación vertical de la cámara
        float xRotation = -mouseY;
        transform.Rotate(xRotation, 0f, 0f);

        // Limitar la rotación vertical de la cámara entre -90 y 90 grados
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, 0f, 90f);
        transform.localEulerAngles = currentRotation;

        // Actualizar la posición de la cámara para que siga al jugador
        transform.position = playerBody.position + offset;
    }
}*/
