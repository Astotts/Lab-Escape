using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ArmTargeting : MonoBehaviour
{

    [SerializeField] private List<Rigidbody2D> armsRB;
    [SerializeField] private List<ArmController> arms;
    private List<Transform> targets;
    [SerializeField] LayerMask layerMask;

    void Awake(){
        targets = new List<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
        for(int x = 0; x < 8; x++){
            for(int y = 0; y < 8; y++){
                if(y == x){
                    continue;
                }
                else if(Vector2.Distance(armsRB[x].transform.position, armsRB[y].transform.position) < 0.05f){
                    armsRB[x].AddForce((armsRB[x].transform.position - armsRB[y].transform.position).normalized * 0.01f);
                    armsRB[y].AddForce((armsRB[y].transform.position - armsRB[x].transform.position).normalized * 0.01f);
                }
            }
        }
        foreach(Collider2D target in Physics2D.OverlapCircleAll(transform.position, 10f, layerMask)){
            if(target != null){
                foreach(ArmController arm in arms){
                    if(arm.target == null){
                        arm.target = target.transform;
                    }
                }
            }
        }
    }
}
