using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingMove : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        /*if(){
            //StartupAnimation
        }
        else{
            //Constant Side Movement
        }*/

        //Side Movement
        transform.Translate(transform.right * moveSpeed * Time.deltaTime);
    }
}
