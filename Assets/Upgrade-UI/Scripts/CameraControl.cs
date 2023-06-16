using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraControl : MonoBehaviour
{
    public float speed = 3;
    public Vector3 Sleeptarget = new Vector3(0,-3.5f,-10f);
    public Vector3 Awaketarget = new Vector3(0,1f,-10f);
    private bool isMoving = false;
    private bool isNap = false;

    public TMP_Text napText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed");
            isMoving = true;
        }

        if(isMoving){
            if(!isNap){//if awake
                takeNap();
            }else{//if asleep
                wakeUp();
            }
        } 
    }

    void takeNap(){
        transform.position = Vector3.MoveTowards(transform.position,Sleeptarget,speed * Time.deltaTime);
        if(transform.position == Sleeptarget){
            isMoving = false;
            isNap = true;
            napText.text = "WakeUp";
        }
    }

    void wakeUp(){
        transform.position = Vector3.MoveTowards(transform.position,Awaketarget,speed * Time.deltaTime);
        if(transform.position == Awaketarget){
            isMoving = false;
            isNap = false;
            napText.text = "Nap";
        }
    }

    public void NapButton(){
        isMoving = true;
    }
    
}
