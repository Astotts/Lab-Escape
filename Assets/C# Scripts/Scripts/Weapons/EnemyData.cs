using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    //Max HP
    public int MaxHP = 10;
    //Current HP
    public int hp;

    void Start()
    {
        hp = MaxHP;
    }

    void Update()
    {
        if(hp <= 0)
        {
            Death();
        }
    }

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
        Debug.Log("Enemy is at " + hp + " HP");
    }

    public void Death()
    {
        //====================
        //TEMPORARY CODE
        Destroy(gameObject);
        //====================

        //Remove the enemy
        //Gift coins
        //Everything else
    }
}