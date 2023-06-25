using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public int level;

    public int gravityRange = 5;
    public float forceSpeed = 10f;

    public float gravityMaxDuration = 10f;
    public float gravityStartTime = 7f;
    public float gravityTime = 0f;

    void Update()
    {
        if (gravityTime < gravityMaxDuration)
        {
            if(gravityTime >= gravityStartTime)
            {
                PullEnemies();
            }
            gravityTime += Time.deltaTime;
        }
        if(gravityTime >= gravityMaxDuration)
        {
            gravityTime = 0;
        }
    }

    public void PullEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if ((enemy.transform.position - transform.position).magnitude <= gravityRange)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, transform.position, forceSpeed * Time.deltaTime);
            }
        }
        gravityTime += Time.deltaTime;
    }

    //This should only be called once immediately after the player levels up an arm
    public void LevelUpdate()
    {
        int weaponlevel = GetComponent<WeaponController>().weaponLevel;
        if (level != weaponlevel)
        {
            level = weaponlevel;
        }

        //Here for reset
        if (level == 1)
        {

        }
        //Increased FireRate
        if (level == 2)
        {
            gravityStartTime = 5;
            gravityMaxDuration = 8;
        }
        //Increased Size
        if (level == 3)
        {
            gravityRange = 8;
        }
    }
}