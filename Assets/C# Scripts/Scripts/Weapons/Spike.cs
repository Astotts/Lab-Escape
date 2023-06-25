using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage = 5;
    public float lifeTime = 5f;
    public float timeLeft = 0f;

    void Update()
    {
        if (timeLeft < lifeTime)
        {
            timeLeft += Time.deltaTime;
        }
        else
        {
            //====================
            //TEMPORARY CODE
            Destroy(gameObject);
            //====================
        }
    }

    //Use OnTriggerEnter for projectiles that only damage once
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.GetComponent<EnemyData>().TakeDamage(damage);

            Debug.Log("Spike has damaged the Enemy");
        }
    }
}
