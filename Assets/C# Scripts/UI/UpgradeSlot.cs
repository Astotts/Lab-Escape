using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UpgradeSlot : MonoBehaviour, IDropHandler
{
    //Slot number in correlation with the tentacle number

    [SerializeField] private int slot;
    [SerializeField] private WeaponMountingSystem weaponMountingSystem;

    public void OnDrop(PointerEventData eventData){
        if(transform.childCount != 0){
            Destroy(transform.GetChild(0).gameObject);
        }

        GameObject dropped = eventData.pointerDrag;
        dragableItem dragableitem = dropped.GetComponent<dragableItem>();
        dragableitem.parrentAfterDrag = transform;
        weaponMountingSystem.AssignWeapon(dragableitem.weaponNumber, slot);
    }
}
