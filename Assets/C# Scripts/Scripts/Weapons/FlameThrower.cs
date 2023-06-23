using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public int level;
    public int damage = 1;

    public float maxCD = 0.5f;
    public float attackCD = 0f;

    void Update()
    {
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

                Debug.Log("FlameThrower has damaged the Enemy");
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

        //Increased FireRate
        if (level == 2)
        {
            maxCD = 0.3f;
        }
    }
}
