using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] private Transform[] tentacleSegPos;
    [SerializeField] private Transform monsterTransform;
    [SerializeField] private Vector3[] lineSegPos;

    [SerializeField] private Rigidbody2D tentacleRB;

    [SerializeField] private Transform endPos;
    [SerializeField] private float maxRadius; //Radius which tentacles snap to
    [SerializeField] private float minRadius; //When point is within radius it will lerp to the outter radius

    

    private bool moving;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        lineSegPos = new Vector3[tentacleSegPos.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.active){
            tentacleRB.bodyType = RigidbodyType2D.Static;
            tentacleSegPos[0].position = monsterTransform.position; //Set origin point of tentacle line
        
            float distance = Vector2.Distance(monsterTransform.position, tentacleSegPos[tentacleSegPos.Length - 1].position);

            if(moving || distance <= minRadius || distance >= maxRadius){ //If the end of the tentacle is within the minradius or exceeding maxradius
                moving = true;
                if(Vector2.Distance(endPos.position, tentacleSegPos[tentacleSegPos.Length - 1].position) < 0.01f){ //If the end of the tentacle is within 1 unit from the end point
                    moving = false;
                    tentacleSegPos[tentacleSegPos.Length - 1].position = endPos.position;
                    //Debug.Log("Snapping");
                }
                else{
                    tentacleSegPos[tentacleSegPos.Length - 1].position = Vector3.MoveTowards(tentacleSegPos[tentacleSegPos.Length - 1].position, endPos.position, speed * Time.deltaTime);
                }
            }
            for(int i = 0; i < tentacleSegPos.Length; i++){
                lineSegPos[i] = tentacleSegPos[i].position;
            }
            lineRenderer.SetPositions(lineSegPos);
        }
        else{
            tentacleRB.bodyType = RigidbodyType2D.Dynamic;
            //Debug.Log(tentacleRB.bodyType);
            //tentacleSegPos[tentacleSegPos.Length - 1].position = Vector3.MoveTowards(tentacleSegPos[tentacleSegPos.Length - 1].position, endPos.position, speed * Time.deltaTime);
            for(int i = 0; i < tentacleSegPos.Length; i++){
                lineSegPos[i] = tentacleSegPos[i].position;
            }
            lineRenderer.SetPositions(lineSegPos);
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(monsterTransform.position, minRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(monsterTransform.position, maxRadius);
    }
}
