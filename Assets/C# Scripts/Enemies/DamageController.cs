using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int health = 4, maxHealth = 4;

    [SerializeField] public AudioClip death;
    [SerializeField] public AudioSource enemyAudio;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        health = maxHealth;
        canvas = GameObject.FindWithTag("UI");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {

            enemyAudio.PlayOneShot(death, 0.7f);
            canvas.GetComponent<BiomassPoints>().AddPoints(maxHealth);
            canvas.GetComponent<ComboManager>().ComboKill();
            Destroy(gameObject, 2f);
        }
    }
    
}
