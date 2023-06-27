using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ArmTargeting : MonoBehaviour
{

    [SerializeField] private List<Rigidbody2D> arms;

    // Update is called once per frame
    void FixedUpdate()
    {
        for(int x = 0; x < 8; x++){
            for(int y = 0; y < 8; y++){
                if(y == x){
                    continue;
                }
                else if(Vector2.Distance(arms[x].transform.position, arms[y].transform.position) < 0.05f){
                    arms[x].AddForce((arms[x].transform.position - arms[y].transform.position).normalized * 0.01f);
                    arms[y].AddForce((arms[y].transform.position - arms[x].transform.position).normalized * 0.01f);
                }
            }
        }
    }
}
