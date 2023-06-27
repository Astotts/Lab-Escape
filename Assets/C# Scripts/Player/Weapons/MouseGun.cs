using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGun : DamageController
{


    private float attackLength = 0.8f;
    private bool isShooting = false;
    private float attackCooldown = float.MaxValue;

    public GameObject bulletPrefab;

    public AudioClip shootSound;
    private AudioSource gunSound;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        gunSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition / 80;

        // Attack target

        if (isShooting == false) //Add conditions that require the tentacle to have lined up the shot towards an enemy
        {
            gunSound.PlayOneShot(shootSound, 0.1f);
            isShooting = true;
            attackCooldown = Time.time + attackLength + Random.Range(0f, 0.1f);
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }

        else if (isShooting == true && attackCooldown < Time.time)
        {
            isShooting = false;
        }

    }
}
