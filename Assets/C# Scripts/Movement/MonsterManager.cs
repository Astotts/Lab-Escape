using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] private Rigidbody2D bodyRB;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.active && transform.position.y <= 0f){
            transform.Translate(transform.up * moveSpeed * Time.deltaTime);
            if(transform.position.y <= -7f){
                transform.position = new Vector3(0f,-5f,0f);
            }
        }
        if(Input.GetButtonDown("Cancel")){
            GameManager.active = !GameManager.active;
            bodyRB.simulated = !GameManager.active;
        }
            
        
    }

    void CamResize(){
        Camera.main.orthographicSize = 5f;
    }
}
