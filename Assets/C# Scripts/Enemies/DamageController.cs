using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int health, maxHealth = 4;

    [SerializeField] public AudioClip death;
    [SerializeField] private AudioSource enemyAudio;

    [SerializeField] private BiomassPoints biomassPoints;
    [SerializeField] private ComboManager comboManager;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        biomassPoints.AddPoints(damage);
        health -= damage;

        if(health <= 0)
        {
            enemyAudio.PlayOneShot(death, 0.7f);
            comboManager.ComboKill();
            Destroy(gameObject, 2f);
        }
    }
    
}
