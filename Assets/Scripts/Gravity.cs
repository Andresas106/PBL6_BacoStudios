using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject[] planetas;
    float velocidad = 3;
    float velRotation = 100;

    private Rigidbody rb;
    private Quaternion targetRotation; // Rotación deseada


    float fuerzasalto = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Buscar el planeta mas cercano

        float distanciaCercana = Vector3.Distance(transform.position, planetas[0].transform.position);
        int planetaCercano = 0;

        for(int i = 0; i < planetas.Length; i++)
        {
            float distAux = Vector3.Distance(transform.position, planetas[i].transform.position);
            if(distAux < distanciaCercana) { distanciaCercana = distAux; planetaCercano = i; }
        }


        Physics.gravity = planetas[planetaCercano].transform.position - transform.position;

        targetRotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation;

        // Suavizar la rotación gradualmente
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 2); // Puedes ajustar el 5 para controlar la velocidad de la rotación suave

        if (Input.GetKey(KeyCode.W)) { transform.Translate(new Vector3(0, 0, velocidad * Time.deltaTime)); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(new Vector3(0, 0, -velocidad * Time.deltaTime)); }
        if (Input.GetKey(KeyCode.A)) { transform.Rotate(new Vector3(0, -velRotation * Time.deltaTime, 0)); }
        if (Input.GetKey(KeyCode.D)) { transform.Rotate(new Vector3(0, velRotation * Time.deltaTime, 0)); }
        if (Input.GetKey(KeyCode.Space)) { rb.AddForce(transform.up * fuerzasalto); }
        
    }
}
