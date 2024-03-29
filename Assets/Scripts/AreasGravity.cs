using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreasGravity : MonoBehaviour
{
    [SerializeField] private int _priority;
    public int Priority => _priority;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Collider>().isTrigger = true;

    }

    public Vector3 GetGravity(GravityPlayer gravityPlayer)
    {
       if(gameObject.tag == "AreaPlanet")
        {
            return (transform.position - gravityPlayer.transform.position).normalized; 
        }

        return Vector3.zero;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GravityPlayer gravityPlayer))
        {
            gravityPlayer.AddAreasGravity(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out GravityPlayer gravityPlayer))
        {
            gravityPlayer.RemoveAreasGravity(this);
        }
    }


}
