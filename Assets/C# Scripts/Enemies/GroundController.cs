using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : DamageController
{
    // SUPER IMPORTANT NOTE: ENEMIES INHERIT FROM DAMAGE CONTROLLER ^
    [SerializeField] private Collider2D mainCollider;
    [SerializeField] private Rigidbody2D rbEnemy;
    private bool deathTriggered = false;
    public float moveSpeed = 1f;

    void Start()
    {
        rbEnemy.velocity = new Vector2(moveSpeed, 0);
        rbEnemy.gravityScale = 1f;

    }

    void Update()
    {
        // Enemy AI
        if (health > 0)
        {


            if (transform.position.x < -6)
            {
                transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            }


            if (transform.position.x > 6)
            {
                transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            }

            rbEnemy.velocity = -transform.right * moveSpeed;


        }
        else if (health <= 0 && deathTriggered != true)
        {


            deathTriggered = true;
            rbEnemy.freezeRotation = false;
            rbEnemy.AddTorque(3f, ForceMode2D.Impulse);


        }

    }
}
