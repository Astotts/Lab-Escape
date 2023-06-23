using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private CircleCollider2D mainCollider;
    private Rigidbody2D rbEnemy;

    private bool isDead = false;

    public AudioClip death;
    private AudioSource enemyAudio;
    private DamageController damageCounter;

    public float moveSpeed = 1f;



    void Start()
    {
        mainCollider = GetComponent<CircleCollider2D>();
        rbEnemy = GetComponent<Rigidbody2D>();
        enemyAudio = GetComponent<AudioSource>();
        damageCounter = GetComponent<DamageController>();
        rbEnemy.velocity = new Vector2(moveSpeed, 0);
        rbEnemy.gravityScale = 0f;

    }

    void Update()
    {

        // Enemy AI


        if (damageCounter.health > 0)
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
        else if (damageCounter.health <= 0 && isDead != true)
        {
            isDead = true;
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

            enemyAudio.PlayOneShot(death, 0.7f);
            Destroy(gameObject, 2f);
        }
    }
}

