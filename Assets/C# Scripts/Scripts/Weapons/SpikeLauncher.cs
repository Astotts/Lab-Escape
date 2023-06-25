using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLauncher : MonoBehaviour
{
    public int level;
    public int damage = 5;

    public float maxCD = 4f;
    public float attackCD = 0f;

    public GameObject spike1;

    void Update()
    {
        //Adjust CoolDown
        if (attackCD < maxCD)
        {
            attackCD += Time.deltaTime;
        } else
        {
            attackCD = 0;
            Launch();
        }
    }

    public void Launch()
    {
        GameObject spike = Instantiate(spike1, transform.position, transform.rotation);

        //==================================================================
        //Edit so that the velocity is directed to the targeted enemy's
        //location
        spike.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
        //
        //==================================================================
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
            maxCD = 3f;
        }
    }
}
