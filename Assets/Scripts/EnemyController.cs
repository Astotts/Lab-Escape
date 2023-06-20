using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private CircleCollider2D mainCollider;
    private Rigidbody2D rbEnemy;

    public float moveSpeed = 1f;

    void Start()
    {
        mainCollider = GetComponent<CircleCollider2D>();
        rbEnemy = GetComponent<Rigidbody2D>();
        rbEnemy.velocity = new Vector2(moveSpeed, 0);

    }

    void Update()
    {
        // Enemy AI
        if (transform.position.x < -2)
        {
            rbEnemy.velocity = new Vector2(moveSpeed, 0);
        }
        else if (transform.position.x > 2)
        {
            rbEnemy.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D touched)
    {
        // Set effect on touch
        transform.position = new Vector3(0, 1, 0);
    }

    public void takeDamage(int amount)
    {
        // Public function to be called to take damage
    }

    public void setup()
    {
        // Public function for setting up specific enemy type
    }

}
