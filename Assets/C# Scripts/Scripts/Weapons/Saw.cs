using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saw : MonoBehaviour
{
    public int level = 1;
    public int damage;

    void Update()
    {
        FollowMousePos();
    }

    void FollowMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        gameObject.transform.position = mousePos2D;
    }

    void Damage()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)    {        if (col.gameObject.tag == "Enemy")        {            Debug.Log("SAW has collided with the Enemy");        }    }
}
