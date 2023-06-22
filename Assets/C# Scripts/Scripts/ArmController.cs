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
    public Vector2 direction;
    private float rotateAmount;
    public float rotateSpeed = 400f;

    void Start()
    {
        // Find components
        targetPos = target.GetComponent<Transform>();
        rbArm = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        direction = this.transform.position - targetPos.transform.position;
        direction = direction.normalized;
        rotateAmount = Vector3.Cross(direction, transform.up).z;
        rbArm.angularVelocity = rotateAmount * rotateSpeed;

        // Attack target
    }

}
