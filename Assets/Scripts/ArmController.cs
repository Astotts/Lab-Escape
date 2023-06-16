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
    public float growSpeed = 0.05f;



    void Start()
    {
        // Find components
        targetPos = target.GetComponent<Transform>();
        rbArm = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (targetPos.position.x > 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180.0f / Mathf.PI * Mathf.Atan((targetPos.position.y - transform.position.y) / (targetPos.position.x - transform.position.x)));
        }

        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f + 180.0f / Mathf.PI * Mathf.Atan((targetPos.position.y - transform.position.y) / (targetPos.position.x - transform.position.x)));
        }


        if (Vector3.Distance(transform.position, targetPos.position) - transform.localScale.x > 0.05 && Vector3.Distance(transform.position, targetPos.position) > transform.localScale.x)
        {
            transform.localScale = new Vector3(transform.localScale.x + growSpeed, 1f, 1f);
        }
        else if (Vector3.Distance(transform.position, targetPos.position) - transform.localScale.x < -0.05)
        {
            transform.localScale = new Vector3(transform.localScale.x - growSpeed, 1f, 1f);
        }

    }

}
