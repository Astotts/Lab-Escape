using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponMountingSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponTypes;
    [SerializeField] private GameObject[] tentaclesMountPoints;
    [SerializeField] private TMP_Text[] costTexts;
    [SerializeField] private TMP_Text[] weaponTexts;
    [SerializeField] private UpgradeSlot[] slots;
    [SerializeField] private BiomassPoints points;
    [SerializeField] private ArmController[] armControllers;


    // Start is called before the first frame update
    void Awake()
    {
       for(int i = 0; i < costTexts.Length - 1; i++){
            weaponTexts[i].text = "Upgrade Arm " + i;
            costTexts[i].text = "0";
        } 
    }

    public void AssignWeapon(int weapon, int mountTentacle){
        GameObject newGun = Instantiate(weaponTypes[weapon], tentaclesMountPoints[mountTentacle].transform);
        newGun.transform.parent = tentaclesMountPoints[mountTentacle].transform;
        costTexts[mountTentacle].text = newGun.GetComponent<GenericWeapon>().cost.ToString();
        Debug.Log(newGun.GetComponent<GenericWeapon>().cost.ToString());
        points.SubtractPoints(newGun.GetComponent<GenericWeapon>().cost);
        armControllers[mountTentacle].weapon = newGun.GetComponent<GenericWeapon>();
    }

    public void UpgradeWeapon(int mountTentacle){
        armControllers[mountTentacle].weapon.GetComponent<WeaponController>().upgradeWeapon(armControllers[mountTentacle].weapon.weaponType);
        costTexts[mountTentacle].text = armControllers[mountTentacle].weapon.cost.ToString();
        points.SubtractPoints(armControllers[mountTentacle].weapon.cost);
    }
}
