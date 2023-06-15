using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biomass_points : MonoBehaviour
{
    private int currency;

    public int Currency{
        get
        {
            return currency;
        }

        set
        {
            this.currency = value;
        }
    }

    void add(int more)
    {
        this.currency += more; 
    }

    // Start is called before the first frame update
    void Start()
    {
        Currency = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
