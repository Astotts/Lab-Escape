using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10.0f;
    private float duration = 1f;
    private float startTime = 0f;
    private int damageOutput = 1;
    public bool hitSomething = false;

    private Animator animator;
    private AudioSource hitSound;
    public AudioClip smallHit;


    public void Start()
    {
        startTime = Time.time;
        hitSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

    }


    void Update()
    {
        if (hitSomething == false)
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }

        if (Time.time > startTime + duration)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D touched)
    {
        if (touched.tag == "Enemy" && hitSomething == false)
        {
            touched.gameObject.GetComponent<DamageController>().TakeDamage(damageOutput);
            animator.SetTrigger("hitSomething");
            hitSomething = true;
            hitSound.PlayOneShot(smallHit, 0.7f);
            Destroy(gameObject, 0.50f);
        }

    }
}