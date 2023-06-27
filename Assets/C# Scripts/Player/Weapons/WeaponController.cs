using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//summary
// Base Script for all weapon controllers
//summary

public class WeaponController : MonoBehaviour
{
    public int weaponLevel = 1;
    
    //0 = Saw               4 = 
    //1 = Flamethrower      5 = 
    //2 = Laser             6 = 
    //3 = Chainsaw          7 = 
    int weaponType;

    public void upgradeWeapon(int buy)
    {
        //Set weaponType to a value depending on the weapon upgraded

        if(weaponType == 0) { LevelSaw(); }
    }

    void LevelSaw()
    {
        GetComponent<Saw>().LevelUpdate();
    }
}
