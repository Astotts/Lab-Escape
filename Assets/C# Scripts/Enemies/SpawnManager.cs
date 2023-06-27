using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject jetpackPrefab;
    public GameObject groundPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 6)
        {
            float roll = Random.Range(0f, 1f);
            if (roll < 0.25f)
            {
                Instantiate(jetpackPrefab, new Vector3(-6f, Random.Range(-2f, 1.7f), 0f), new Quaternion(0f, 0f, 0f, 0f));
            }
            else if (roll < 0.50f)
            {

                Instantiate(groundPrefab, new Vector3(-6f, -2.5f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            }
            else if (roll < 0.75f)
            {

                Instantiate(groundPrefab, new Vector3(6f, -2.5f, 0f), new Quaternion(0f, 180f, 0f, 0f));
            }
            else
            {
                Instantiate(jetpackPrefab, new Vector3(6f, Random.Range(-2f, 1.7f), 0f), new Quaternion(0f, 180f, 0f, 0f));
            }

        }

    }
}
