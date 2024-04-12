using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleted : MonoBehaviour
{

    private ObjectCount notes;

    void Start()
    {
        notes = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectCount>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (notes.quantity == ObjectCount.MAX_QUANTITY)
        {
            //Hacer algo para que el jugador tenga la opcion de ir al siguiente nivel
        }
    }
}
