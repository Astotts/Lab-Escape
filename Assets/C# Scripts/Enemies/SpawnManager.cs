using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject scientistPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 4)
        {
            Instantiate(scientistPrefab, new Vector3(Random.Range(-4f, 4f), Random.Range(-1.75f, 0f), 0f), new Quaternion(0f, 0f, 0f, 0f));
        }
    }
}
