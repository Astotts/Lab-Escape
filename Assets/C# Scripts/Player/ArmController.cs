using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    // Onboard components
    private BoxCollider2D mainCollider;
    [SerializeField] private Rigidbody2D tentacleRB;
    private Transform armPos;

    //Targeting
    private Transform target;

    // Tuning variables
    private Vector2 direction;
    private float rotateAmount;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;

    //Positioning Tentacle
    private Vector2 endPos;
    [SerializeField] private Transform tentacleEnd;
    [SerializeField] private Transform monsterTransform;
    [SerializeField] private float maxRadius; //Radius which tentacles snap to
    [SerializeField] private float minRadius; //When point is within radius it will lerp to the outter radius
    private float _radius = 0f; //computed/active radius
    private float elapsed;
    private Vector2 destinationPos;

    //LineRenderer Components
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] private Transform[] tentacleSegPos;
    [SerializeField] private Vector3[] lineSegPos;
    
    void FixedUpdate()
    {
        if(GameManager.active){
            tentacleRB.gravityScale = 0f;
            tentacleSegPos[0].position = monsterTransform.position; //Set origin point of tentacle line
        
            float distance = Vector2.Distance(monsterTransform.position, tentacleSegPos[tentacleSegPos.Length - 1].position);
            if(Vector2.Distance(endPos, tentacleSegPos[tentacleSegPos.Length - 1].position) < 0.01f){ //If the end of the tentacle is within 1 unit from the end point
                tentacleSegPos[tentacleSegPos.Length - 1].position = endPos;
                //Debug.Log("Snapping");
            }
            else if(target != null){//Extend to attack     
                //snaps the end of the tentacle to the edge of an imaginary circle with a specified radius
                //Debug.Log("Extending");
                direction = this.transform.position - target.position;
                direction.Normalize();
                rotateAmount = Vector3.Cross(direction, tentacleEnd.up).z;
                tentacleRB.angularVelocity = -rotateAmount * rotateSpeed;
                if(elapsed < 1f){ 
                    elapsed += moveSpeed * Time.deltaTime / 10f;
                    _radius = Mathf.Lerp(_radius, maxRadius, elapsed);
                }
                _radius = Mathf.Clamp(_radius, minRadius, maxRadius);
                RotateAround(10f);
            }    
            else if(target == null){
                target = GameObject.FindWithTag("Enemy").transform; 
            }
        }
        else{
            tentacleRB.gravityScale = 1f;
        }
        for(int i = 0; i < tentacleSegPos.Length; i++){
            lineSegPos[i] = tentacleSegPos[i].position;
        }
        lineRenderer.SetPositions(lineSegPos);
    }
    
    private void RotateAround(float deg){
        destinationPos = Vector2.zero;
        if(target != null){
            if(Vector2.Distance(tentacleEnd.position, destinationPos) < 0.01f){
                tentacleEnd.position = destinationPos;
                return;
            }

            tentacleRB.velocity = (target.position - tentacleEnd.position) * Time.deltaTime * 100;
        
            if(Vector2.Distance(tentacleEnd.position, monsterTransform.position) > 1.5f){
                float angle = (Vector3.Angle(monsterTransform.position, tentacleEnd.position) - 90) / 180 * Mathf.PI;
                float x = _radius * Mathf.Cos(angle) + monsterTransform.position.x;
                float y = _radius * Mathf.Sin(angle) + monsterTransform.position.y;
                tentacleEnd.position = new Vector3(x, y, 0f);
            }
        }
        

    }

    void OnDrawGizmos(){
        if(target != null){
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(target.position, 5f);
            Gizmos.DrawWireSphere(monsterTransform.position, _radius);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(destinationPos, 2f);
            //Debug.DrawRay(tentacleEnd.position, direction, Color.red, 0.1f, false);
        }
        
    }

    public void Kick(float kick){
        tentacleRB.AddForce((tentacleEnd.position - (tentacleEnd.forward)) * kick);
    }
}
