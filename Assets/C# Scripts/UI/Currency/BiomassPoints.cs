using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BiomassPoints : MonoBehaviour
{   
    
    public int points;

    [SerializeField] private TMP_Text currencyTxt; 

    public bool addPoints(int more)
    {
        if(more < 0)
            return false;
    
        this.points += more;
        this.currencyTxt.text = this.points.ToString();
        return true; 
    }

    public bool subtractPoints(int less)
    {
        if((this.points - less) <= 0)
        {
            return false;
        }
        this.points -= less;
        currencyTxt.text = this.points.ToString();
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.points = 100;
        this.currencyTxt.text = this.points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
