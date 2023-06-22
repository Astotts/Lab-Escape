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

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
        Debug.Log("Enemy was Hit!");
    }
}