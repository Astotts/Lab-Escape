using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//summary
// Base Script for all weapon controllers
//summary

public class WeaponController : MonoBehaviour
{
    public int cost;

    public int weaponLevel = 1;
    
    //0 = Saw               4 = Spike Launcher
    //1 = Flamethrower      5 = Magnet
    //2 = Laser             6 = 
    //3 = Chainsaw          7 = 
    int weaponType;

    public void upgradeWeapon(int buy)
    {
        weaponLevel++;
        //Set weaponType to a value depending on the weapon upgraded

        switch(buy){
            case 0:
                GetComponent<Saw>().LevelUpdate();
            break;
            case 1:
                GetComponent<FlameThrower>().LevelUpdate();
            break;
            case 2:
                GetComponent<LaserLauncher>().LevelUpdate();
            break;
            case 3:
                GetComponent<BuzzSaw>().LevelUpdate();
            break;
            case 4:
                GetComponent<ProjectileLauncher>().LevelUpdate();
            break;
            case 5:
                GetComponent<Magnet>().LevelUpdate();
            break;
        }
    }
    
}
