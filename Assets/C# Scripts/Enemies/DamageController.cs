using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int health = 4, maxHealth = 4;

    [SerializeField] public AudioClip death;
    [SerializeField] public AudioSource enemyAudio;

    [SerializeField] private GameObject canvas;
    private BiomassPoints biomassPoints;
    private ComboManager comboManager;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        biomassPoints = canvas.GetComponent<BiomassPoints>();
        comboManager = canvas.GetComponent<ComboManager>();
    }


    public void TakeDamage(int damage)
    {
        //biomassPoints.AddPoints(damage);
        health -= damage;

        if(health <= 0)
        {
            enemyAudio.PlayOneShot(death, 0.7f);
            //comboManager.ComboKill();
            Destroy(gameObject, 2f);
        }
    }
    
}
