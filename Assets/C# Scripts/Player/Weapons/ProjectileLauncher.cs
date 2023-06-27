using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public int level;

    public float maxCD = 4f;
    public float attackCD = 0f;

    public GameObject proj1;
    public GameObject proj2;

    private GameObject projToSpawn;

    public float xForce, yForce;

    void Start()
    {
        projToSpawn = proj1;
    }

    void Update()
    {
        LevelUpdate();

        //Adjust CoolDown
        if (attackCD < maxCD)
        {
            attackCD += Time.deltaTime;
        }
        else
        {
            attackCD = 0;
            Launch();
        }
    }

    public void Launch()
    {
        GameObject projectile = Instantiate(projToSpawn, transform.position, transform.rotation);

        //==================================================================
        //Edit so that the velocity is directed to the targeted enemy's
        //location
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(xForce, yForce, 0);
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

        //Here for reset
        if (level == 1)
        {
            projToSpawn = proj1;
            maxCD = 4f;
        }
        //Increased FireRate
        if (level == 2)
        {
            maxCD = 3f;
        }
        //Increased Size with new Spike
        if (level == 3)
        {
            projToSpawn = proj2;
        }
    }
}
