using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    Vector2 worldPos; //top left corner of the first chunk in this chunk
    Vector2 bounds;
    Vector2Int GridPos;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate(){
        for(int x = 0; x < bounds.x; x++){
            for(int y = 0; y < bounds.y; y++){

            }
        }
    }

    bool IsWithinChunk(Transform posToCheck){
        if(posToCheck.x > worldPos.x && posToCheck.x > worldPos.x + (bounds.x/* * unit conversion*/)){
            return true;
        }
        return false;
    }
}
