using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    // Onboard components
    private BoxCollider2D mainCollider;
    private Rigidbody2D rbArm;
    private Vector3 armPos;

    // Offboard components
    public GameObject target;
    private Transform targetPos;


    // Tuning variables
    public float turnSpeed = 1f;

    void Start()
    {
        // Find components
        targetPos = target.GetComponent<Transform>();
        rbArm = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        // Track target
        Vector3 relative = transform.InverseTransformPoint(target.transform.position);
        float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, angle);
        
        // Attack target
    }

}
