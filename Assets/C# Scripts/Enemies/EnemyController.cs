using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : DamageController
{
    // SUPER IMPORTANT NOTE: ENEMIES INHERIT FROM DAMAGE CONTROLLER ^
    [SerializeField] private Collider2D mainCollider;
    [SerializeField] private Rigidbody2D rbEnemy;
    public float moveSpeed = 1f;

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
            if (transform.position.x < -4)
            {
                rbEnemy.velocity = new Vector2(moveSpeed, 0);
            }
            else if (transform.position.x > 4)
            {
                rbEnemy.velocity = new Vector2(-moveSpeed, 0);
            }
        }
        else if(health <= 0){
            rbEnemy.gravityScale = 1f;

            if (transform.position.x < 0)
            {
                rbEnemy.velocity = new Vector2(-2, 2);
                rbEnemy.angularVelocity = 1f;
            }
            else
            {
                rbEnemy.velocity = new Vector2(2, 2);
            }
        }
    }
}

