using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackController : DamageController
{
    // SUPER IMPORTANT NOTE: ENEMIES INHERIT FROM DAMAGE CONTROLLER ^
    [SerializeField] private Collider2D mainCollider;
    [SerializeField] private Rigidbody2D rbEnemy;
    private bool deathTriggered = false;
    public float moveSpeed = 2f;

    private float attackLength = 0.8f;
    private bool isShooting = false;
    private float attackCooldown = float.MaxValue;

    [SerializeField] private GameObject bulletPrefab;

    public AudioClip shootSound;


    void Start()
    {
        rbEnemy.velocity = new Vector2(moveSpeed, 0);
        rbEnemy.gravityScale = 0f;

    }

    void Update()
    {
        // Enemy AI
        if (health > 0)
        {

            // Movement

            if (transform.position.x < -6)
            {
                transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            }


            if (transform.position.x > 6)
            {
                transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            }

            rbEnemy.velocity = -transform.right * moveSpeed;
            rbEnemy.AddForce(new Vector3(0f, Random.Range(-1f, 1f), 0f), ForceMode2D.Impulse);


            // Attack target

            if (isShooting == false) //Add conditions that require the tentacle to have lined up the shot towards an enemy
            {
                enemyAudio.PlayOneShot(shootSound, 0.1f);
                isShooting = true;
                attackCooldown = Time.time + attackLength + Random.Range(0f, 0.1f);
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }

            else if (isShooting == true && attackCooldown < Time.time)
            {
                isShooting = false;
            }


        }
        else if(health <= 0 && deathTriggered != true){


            deathTriggered = true;
            rbEnemy.freezeRotation = false;
            rbEnemy.gravityScale = 1f;
            rbEnemy.AddTorque(3f, ForceMode2D.Impulse);

        }


    }


}

