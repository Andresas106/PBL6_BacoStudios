using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GravityPlayer : MonoBehaviour
{
    private static float GRAVITY_FORCE = 800;
    private List<AreasGravity> _areas;
    private Rigidbody _rb;

    public Vector3 Direction
    {
        get
        {
            if (_areas.Count == 0) return Vector3.zero;
            _areas.Sort((area1, area2) => area1.Priority.CompareTo(area2.Priority));
            return _areas.Last().GetGravity(this).normalized;
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _areas = new List<AreasGravity>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(Direction * (GRAVITY_FORCE * Time.fixedDeltaTime), ForceMode.Acceleration);
        Quaternion upRotation = Quaternion.FromToRotation(transform.up, -Direction);
        Quaternion newRotation = Quaternion.Slerp(_rb.rotation, upRotation * _rb.rotation, Time.fixedDeltaTime * 3f);
        _rb.MoveRotation(newRotation);
    }

    public void AddAreasGravity(AreasGravity gravityArea)
    {
        _areas.Add(gravityArea);
    }

    public void RemoveAreasGravity(AreasGravity gravityArea)
    {
        _areas.Remove(gravityArea);
    }
}
