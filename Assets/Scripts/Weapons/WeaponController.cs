using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//summary
// Base Script for all weapon controllers
//summary

public class WeaponController : MonoBehaviour
{
    public int weaponLevel;

    [SerializeField] private BiomassPoints points;

    public bool upgradeWeapon(int buy)
    {
        if(points.subtractPoints(buy))
            return true;
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponLevel = 0;
        upgradeWeapon(20);
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}
