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

    private float attackLength = 0.8f;
    private bool isShooting = false;
    private float attackCooldown = float.MaxValue;

    public GameObject bulletPrefab;
    public Transform armLengthOffset;

    public AudioClip shootSound;
    private AudioSource armSound;



    void Start()
    {
        // Find components
        targetPos = target.GetComponent<Transform>();
        rbArm = GetComponent<Rigidbody2D>();
        armSound = GetComponent<AudioSource>();

    }

    void Update()
    {

        if (target)
        {
            float desiredAngle = Mathf.Atan2(target.transform.position.y, target.transform.position.x);
            rotateAmount = Mathf.DeltaAngle(transform.rotation.z, desiredAngle);
            transform.Rotate(0f, 0f, rotateAmount * rotateSpeed, 0f);
        }

        else if (GameObject.FindWithTag("Enemy") != null)
        {
            target = GameObject.FindWithTag("Enemy");
        }
       

        // Attack target

        if (isShooting == false)
        {
            armSound.PlayOneShot(shootSound, 0.1f);
            isShooting = true;
            attackCooldown = Time.time + attackLength;
            Instantiate(bulletPrefab, armLengthOffset.position, transform.rotation);
        }

        else if (isShooting == true && attackCooldown < Time.time)
        {
            isShooting = false;
        }
    }
}
