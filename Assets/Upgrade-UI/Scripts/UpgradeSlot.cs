using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData){
        if(transform.childCount != 0){
            Destroy(transform.GetChild(0).gameObject);
        }

        GameObject dropped = eventData.pointerDrag;
        dragableItem dragableitem = dropped.GetComponent<dragableItem>();
        dragableitem.parrentAfterDrag = transform;
    }
}
