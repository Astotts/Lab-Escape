using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saw : MonoBehaviour
{
    public int level;
    public int damage = 1;

    public float maxCD = 1f;
    public float attackCD = 0f;

    void Update()
    {
        LevelUpdate();

        FollowMousePos();

        //Adjust CoolDown
        if (attackCD < maxCD)
        {
            attackCD += Time.deltaTime;
        }
    }

    void FollowMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        gameObject.transform.position = mousePos2D;
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

                Debug.Log("SAW has damaged the Enemy");
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
            this.transform.localScale = new Vector3(2, 2, 1);
            maxCD = 1f;
            damage = 1;
        }
        //Increased size and damage
        if (level == 2)
        {
            this.transform.localScale = new Vector3(3, 3, 1);
            damage = 2;
        }
        //Increased FireRate
        if (level == 3)
        {
            maxCD = 0.5f;
        }
    }
}
