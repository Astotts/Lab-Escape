using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] private Rigidbody2D bodyRB;
    private float elapsed = 0f;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.active && transform.position.y <= 0f){
            transform.Translate(transform.up * moveSpeed * Time.deltaTime);
            if(transform.position.y <= -7f){
                transform.position = new Vector3(0f,-5f,0f);
            }
        }
        bodyRB.simulated = !GameManager.active;

        if(GameManager.active){
            elapsed += Time.deltaTime / 2f;
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Mathf.Clamp(2f / Mathf.Clamp(Mathf.Abs(transform.position.y), 1f, 5f), 1f, 3f), elapsed);
        }
        else{
            elapsed = 0f;
        }
        
    }
}
