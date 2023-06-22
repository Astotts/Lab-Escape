using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiomassPoints : MonoBehaviour
{   
    
    public int points;
    public Text currencyTxt;

    //USE WITH POSITIVE VALUES ONLY (USE FOR GIVING PLAYER POINTS)
    public void addPoints(int more)
    {
        if (validAddPoints(more))
        {
            this.points += more;
            this.currencyTxt.text = this.points.ToString() + "<color=lime>$</color>";
            //Could add a sound here meaning that points increased
        }
    }
    private bool validAddPoints(int more)
    {
        if(more < 0)
            return false;
        return true; 
    }

    //USE NEGATIVE VALUES ONLY (USE FOR SHOP)
    public void subtractPoints(int less)
    {
        if (validSubtractPoints(less))
        {
            this.points += less;
            this.currencyTxt.text = this.points.ToString() + "<color=lime>$</color>";
            //Add sound code here meaning that purchase was valid
        }
        else
        {
            //Add sound code here meaning that purchase was invalid
        }
    }
    private bool validSubtractPoints(int less)
    {
        if((this.points - less) <= 0)
            return false;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.points = 100;
        this.currencyTxt.text = this.points.ToString() + "<color=lime>$</color>";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
