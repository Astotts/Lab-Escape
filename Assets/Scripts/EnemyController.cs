using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private CircleCollider2D mainCollider;
    private Rigidbody2D rbEnemy;

    private float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        mainCollider = GetComponent<CircleCollider2D>();
        rbEnemy = GetComponent<Rigidbody2D>();
        rbEnemy.velocity = new Vector2(moveSpeed, 0);

    }

    // Update is called once per frame
    void Update()
    {
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
        transform.position = new Vector3(0, 1, 0);
    }

}
