using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public float speed = 3;
    [SerializeField] private RectTransform openPos;
    [SerializeField] private RectTransform closePos;
    [SerializeField] private RectTransform uiPos;

    [SerializeField] private TMP_Text napText;

    private float elapsed = 0f;
    private void Update(){
        if(Input.GetButtonDown("Cancel")){
            NapWakeUp();
            elapsed = 0;
        }
        if(!GameManager.active){
            elapsed += Time.deltaTime / 2f;
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 2f, elapsed);
        }
    }

    public void NapWakeUp(){
        GameManager.active = !GameManager.active;
        if(GameManager.active){
            napText.text = "Sleep";
            StartCoroutine(UIAnim(closePos));
        }
        else{
            napText.text = "Awake";
            StartCoroutine(UIAnim(openPos));
        }
    }

    IEnumerator UIAnim(RectTransform destination){
        float time = 0;
        float distance = Vector2.Distance((Vector3)destination.position, (Vector3)uiPos.position);
        Debug.Log("Started");
        while(distance > 0.01f){
            time += Time.deltaTime;
            distance = Vector2.Distance((Vector3)destination.position, (Vector3)uiPos.position);
            uiPos.position = Vector3.Lerp((Vector3)uiPos.position, (Vector3)destination.position, time);
            if(distance <= 0.01f){
                uiPos.position = destination.position;
                Debug.Log("Ended");
                yield break;       
            }
            yield return null;
        }
        uiPos.position = destination.position;
        Debug.Log("Ended1");
        yield break; 
    }
}
