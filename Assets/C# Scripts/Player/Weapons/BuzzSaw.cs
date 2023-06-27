using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzSaw : GenericWeapon
{
    public int level;
    public int damage = 2;
    

    public float maxCD = 1f;
    public float attackCD = 0f;

    [SerializeField] private WeaponController weaponController;

    public List<GameObject> enemyList = new List<GameObject>();

    void Awake(){
        enemyList = new List<GameObject>();
    }

    void Update()
    {
        LevelUpdate();

        //Adjust CoolDown
        if (attackCD < maxCD)
        {
            attackCD += Time.deltaTime;
        }
        if(attackCD >= maxCD)
        {
            attackCD = 0;
            DamageEnemies();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        enemyList.Add(col.gameObject);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        enemyList.Remove(col.gameObject);
    }

    void DamageEnemies()
    {
        foreach (GameObject enemy in enemyList)
        {
            if(enemy == null)
            {
                enemyList.Remove(enemy.gameObject);
            }
            else{
                Debug.Log(enemy.GetComponent<DamageController>());
                enemy.GetComponent<DamageController>().TakeDamage(damage);
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
            cost *= level;
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
