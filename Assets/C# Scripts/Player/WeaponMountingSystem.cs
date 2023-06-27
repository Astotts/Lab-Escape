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


    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0; i < costTexts.Length - 1; i++){
            weaponTexts[i].text = "Upgrade";
            costTexts[i].text = "0";
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignWeapon(int weapon, int mountTentacle){
        GameObject newGun = Instantiate(weaponTypes[weapon], tentaclesMountPoints[mountTentacle].transform);
        newGun.transform.parent = tentaclesMountPoints[mountTentacle].transform;
        weaponTexts[mountTentacle].text = "Upgrade";
        costTexts[mountTentacle].text = newGun.GetComponent<GenericWeapon>().cost.ToString();
        points.SubtractPoints(newGun.GetComponent<GenericWeapon>().cost);
    }
}
