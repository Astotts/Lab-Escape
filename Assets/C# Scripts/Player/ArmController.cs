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

    private float _radius = 0f; //computed/active radius
    [SerializeField] private float radius; //maxiumum radius

    [SerializeField] private Transform tentacleEnd;
    private Transform _target;



    void Start()
    {
        // Find components
        rbArm = GetComponent<Rigidbody2D>();
        armSound = GetComponent<AudioSource>();

    }

    void Update()
    {
        

      /*  if (target)
        {
            if(target != null){
                //Facing of the weapon
                direction = tentacleEnd.position - targetPos;
                direction = direction.normalized;
                rotateAmount = Vector3.Cross(direction, transform.up).z;
                unitRB.angularVelocity = rotateAmount * rotateSpeed;

                //snaps the end of the tentacle to the edge of an imaginary circle with a specified radius
                if(angle == 0){
                    angle = (tentacleEnd.eulerAngles.z - 90) / 180 * Mathf.PI;
                    unitRB.velocity = Vector2.zero;
                }
                //Lerp Radius from current radius to max radius (The radius should increase when the tentacle is within a few degrees of pointing at the target and decrease when the tentacle is far from pointing at the target)
                RotateAround(50f, _radius);
            }
            //float desiredAngle = Mathf.Atan2(target.transform.position.y, target.transform.position.x) * Mathf.Rad2Deg;
            //rotateAmount = Mathf.DeltaAngle(transform.rotation.z, desiredAngle) * Mathf.Deg2Rad; 
            //transform.Rotate(0f, 0f, Random.Range(-1f, 1f) + rotateAmount * rotateSpeed, 0f);
        }
        else
        {
            angle = 0;
            target = GameObject.FindWithTag("Enemy"); 
            if(target != null){
                targetPos = target.transform;
            }
            else{
                Debug.Warning("No Enemies Found");
            }
        }
       

        // Attack target

        if (isShooting == false) //Add conditions that require the tentacle to have lined up the shot towards an enemy
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

    public void SetTarget(Transform target){
        destination = target;
    }

    private Vector3 RotateAround(float deg, float radius){
        unitRB.velocity = Vector2.zero;
        float x = 0;
        float y = 0;
        if(Vector3.Distance(tentacleEnd.right + tentacleEnd.position, destination.position -destination.up * 30f) > Vector3.Distance(-tentacleEnd.right + tentacleEnd.position, destination.position -destination.up * 30f)){
            angle -= deg * Mathf.Deg2Rad * Time.deltaTime;
        }
        else{
            angle += deg * Mathf.Deg2Rad * Time.deltaTime;
        }
        
        x = radius * Mathf.Cos(angle) + destination.position.x;
        y = radius * Mathf.Sin(angle) + destination.position.y;

        transform.postion = Vector3.Lerp(transform.position, new Vector3(x, y, 0f), Time.deltaTime);*/
    }
}