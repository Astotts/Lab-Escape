using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    private List<Chunk> world;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateNext(){
        //Chunk newChunk = new Chunk{};
        world.Add(newChunk);
        world.RemoveAt(0);
    }
}
