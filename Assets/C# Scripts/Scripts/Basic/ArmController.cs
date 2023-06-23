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
    private GameObject target;
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
        rbArm = GetComponent<Rigidbody2D>();
        armSound = GetComponent<AudioSource>();

    }

    void Update()
    {

        if (target)
        {
            float desiredAngle = Mathf.Atan2(target.transform.position.y, target.transform.position.x) * Mathf.Rad2Deg;
            rotateAmount = Mathf.DeltaAngle(transform.rotation.z, desiredAngle) * Mathf.Deg2Rad; 
            transform.Rotate(0f, 0f, Random.Range(-1f, 1f) + rotateAmount * rotateSpeed, 0f);
        }

        else if (GameObject.FindWithTag("Enemy") != null)
        {
            target = GameObject.FindWithTag("Enemy");
            targetPos = target.GetComponent<Transform>();
        }
       

        // Attack target

        if (isShooting == false)
        {
            armSound.PlayOneShot(shootSound, 0.1f);
            isShooting = true;
            attackCooldown = Time.time + attackLength + Random.Range(0f, 0.1f);
            Instantiate(bulletPrefab, armLengthOffset.position, transform.rotation);
        }

        else if (isShooting == true && attackCooldown < Time.time)
        {
            isShooting = false;
        }
    }
}
