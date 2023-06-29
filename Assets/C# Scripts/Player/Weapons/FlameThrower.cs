using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : GenericWeapon
{
    public int level;
    public int damage = 1;
    public float maxCD = 0.5f;
    public float attackCD = 0f;

    public List<GameObject> enemyList = new List<GameObject>();

    void Update()
    {
        LevelUpdate();

        //Adjust CoolDown
        if (attackCD < maxCD)
        {
            attackCD += Time.deltaTime;
        }
        if (attackCD >= maxCD)
        {
            attackCD = 0;
            DamageEnemies();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            enemyList.Add(col.gameObject);
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            enemyList.Remove(col.gameObject);
        }
    }

    void DamageEnemies()
    {
        foreach (GameObject enemy in enemyList)
        {
            if (enemy == null)
            {
                enemyList.Remove(enemy.gameObject);
            }
            if(enemy != null)
            {
                enemy.GetComponent<DamageController>().TakeDamage(damage);
                Debug.Log("Flamethrower has damaged the Enemy");
            }
        }
    }

    //This should only be called once immediately after the player levels up an arm
    public void LevelUpdate()
    {
        int weaponlevel = GetComponent<WeaponController>().weaponLevel;
        if (level != weaponlevel)
        {
            Debug.Log("upgraded");
            level = weaponlevel;
            cost *= level;
        }

        //Here for reset
        if (level == 1)
        {
            maxCD = 0.5f;
        }
        //Increased FireRate
        if (level == 2)
        {
            maxCD = 0.3f;
        }
        //Increased Damage
        if (level == 3)
        {
            damage = 2;
        }
    }
}
