using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
     public Transform parrentAfterDrag;//to set as first child of canvas
    private Canvas parentCanvasOfImageToMove;

    public void OnBeginDrag(PointerEventData eventData){
        //Debug.Log("begin drag");
        Instantiate(gameObject,transform.position,transform.rotation,transform.parent);//make another version of for display
        parrentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        parentCanvasOfImageToMove = gameObject.transform.parent.gameObject.GetComponent<Canvas>();
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData){
        //Debug.Log("dragging");
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent as RectTransform, Input.mousePosition, parentCanvasOfImageToMove.worldCamera, out pos);
        //imageToMove.transform.position = parentCanvasOfImageToMove.transform.TransformPoint(pos);
        transform.position = parentCanvasOfImageToMove.transform.TransformPoint(pos);
    }

    public void OnEndDrag(PointerEventData eventData){
        //Debug.Log("endDrag");
        transform.SetParent(parrentAfterDrag);
        image.raycastTarget = true;
        StopAllCoroutines();
        StartCoroutine(Deletion());
        
    }

    IEnumerator Deletion(){
        yield return new WaitForSeconds(3);
        if(gameObject.transform.parent.gameObject.GetComponent<UpgradeSlot>() == null)
            Destroy(gameObject);
    }
    
}
