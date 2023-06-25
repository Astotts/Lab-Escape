using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzSaw : MonoBehaviour
{
    public int level;
    public int damage = 2;

    public float maxCD = 1f;
    public float attackCD = 0f;

    void Update()
    {
        LevelUpdate();

        //Adjust CoolDown
        if (attackCD < maxCD)
        {
            attackCD += Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Check Weapon CoolDown
            if (attackCD >= maxCD)
            {
                attackCD = 0f;

                col.GetComponent<EnemyData>().TakeDamage(damage);

                Debug.Log("BuzzSaw has damaged the Enemy");
            }
        }
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
            maxCD = 1f;
            damage = 2;
        }
        //Increased damage
        if (level == 2)
        {
            damage = 4;
        }
        //Increased FireRate
        if (level == 3)
        {
            maxCD = 0.6f;
        }
    }
}
