using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBodyAnimation : MonoBehaviour
{
    Animator _animator; // Referencia al componente Animator del objeto.
    public bool ikActive = false; // Indica si el IK (inversi�n cinem�tica) est� activado.
    public float lookWeight; // Controla la influencia de la mirada en la animaci�n.
    public float desireDist; // Distancia deseada para considerar un objetivo.
    public Transform pivot; // Un transform para definir un punto de referencia para el look-at.

    private Transform currentTarget;  // El objetivo actual al que el objeto est� mirando.

    private void Start()
    {
        // Obtiene el componente Animator del objeto.
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Encuentra todos los objetos con la etiqueta "Enemigo".
        var npcs = GameObject.FindGameObjectsWithTag("target_npc");

        // Si no hay enemigos, no hacemos nada y salimos.
        if (npcs.Length == 0)
            return;

        // Encuentra el enemigo m�s cercano para definir como objetivo.
        currentTarget = GetClosestTarget(npcs);

        if (currentTarget != null)
        {
            // Hace que el pivote mire al objetivo actual.
            pivot.transform.LookAt(currentTarget);

            // Obtiene la rotaci�n en el eje Y del pivote.
            float pivotRotY = pivot.transform.localRotation.y;

            // Calcula la distancia entre el pivote y el objetivo actual.
            float dist = Vector3.Distance(pivot.transform.position, currentTarget.position);

            // Si la rotaci�n en Y est� dentro de un rango y la distancia es menor que la deseada...
            if (pivotRotY > -0.5f && pivotRotY < 0.5f && dist < desireDist)
            {
                // ... incrementamos gradualmente el peso de la mirada.
                lookWeight = Mathf.Lerp(lookWeight, 1, Time.deltaTime * 2.5f);
            }
            else
            {
                // Si no, reducimos gradualmente el peso de la mirada.
                lookWeight = Mathf.Lerp(lookWeight, 0, Time.deltaTime * 2.5f);
            }
        }
    }

    // M�todo para configurar el IK del Animator.
    private void OnAnimatorIK(int layerIndex)
    {
        if (_animator) // Asegura que el Animator no sea nulo.
        {
            if (ikActive) // Si el IK est� activo...
            {
                if (currentTarget != null) // Si hay un objetivo actual...
                {
                    // Configura el peso de la mirada y la posici�n del objetivo.
                    _animator.SetLookAtWeight(lookWeight);
                    _animator.SetLookAtPosition(currentTarget.position);
                }
                else
                {
                    // Si no hay objetivo, el peso de la mirada es cero.
                    _animator.SetLookAtWeight(0);
                }
            }
        }
    }

    // M�todo para encontrar el enemigo m�s cercano.
    private Transform GetClosestTarget(GameObject[] npcs)
    {
        Transform closest = null; // Variable para guardar el objetivo m�s cercano.
        float closestDistance = float.MaxValue; // Variable para la distancia m�nima.

        // Recorre todos los enemigos para encontrar el m�s cercano.
        foreach (var npc in npcs)
        {
            // Calcula la distancia entre el pivote y el enemigo.
            float distance = Vector3.Distance(pivot.transform.position, npc.transform.position);

            // Si esta distancia es menor que la distancia m�s cercana hasta ahora...
            if (distance < closestDistance)
            {
                // Actualizamos el m�s cercano y su distancia.
                closest = npc.transform;
                closestDistance = distance;
            }
        }

        return closest; // Retorna el enemigo m�s cercano.
    }
}