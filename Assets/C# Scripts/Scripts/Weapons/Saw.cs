using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saw : MonoBehaviour
{
    public int level = 1;
    public int damage = 1;

    public float maxCD = 1f;
    public float attackCD = 0f;

    void Update()
    {
        FollowMousePos();

        //Adjust CoolDown
        if (attackCD < maxCD)
        {
            attackCD += Time.deltaTime;
        }
    }

    void FollowMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        gameObject.transform.position = mousePos2D;
    }

    void OnTriggerStay2D(Collider2D col)    {        if (col.gameObject.tag == "Enemy")        {
            //Check Weapon CoolDown
            if (attackCD >= maxCD)
            {
                attackCD = 0f;

                col.GetComponent<EnemyData>().TakeDamage(damage);

                Debug.Log("SAW has damaged the Enemy");
            }        }    }
}
