using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class ResetControl : MonoBehaviour
{
    [Tooltip("determine increments")]
    public float multipilerAmount = 2;
    [Tooltip("equation is:  y = ((multipilerAmount)^x) * (1/multiplilerWidth) + (multiplilerWidth-1)/multiplilerWidth")]
    public float multiplilerWidth = 1;
    public int goal = 1000;
    private bool boolReset = false;
    private BiomassPoints points;

    void Start(){
        points = transform.root.GetComponent<BiomassPoints>();
        if(!PlayerPrefs.HasKey("pointsMultiplier")){
            PlayerPrefs.SetFloat("pointsMultiplier",1);//default
        }
        if(!PlayerPrefs.HasKey("pointsGoal")){
            PlayerPrefs.SetInt("pointsGoal",goal);//default
        }
    }

    void Update(){
        if(points.points >= PlayerPrefs.GetFloat("pointsGoal") && !boolReset){
           gameObject.transform.GetChild(0).gameObject.SetActive(true);
           boolReset = true;
        }
    }


    public void GameReset(){
        //stuff that needs to save

        //unlock fish weapons

        //bonus multiplier
        var mult = PlayerPrefs.GetFloat("pointsMultiplier");
        mult = (mult * multipilerAmount)* (1/multiplilerWidth) + ((multiplilerWidth-1)/multiplilerWidth);
        PlayerPrefs.SetFloat("pointsMultiplier",mult);

        var goalmult = PlayerPrefs.GetInt("pointsGoal");
        goalmult = goalmult* (int)multipilerAmount;
        //this should make the goal harder to get to compared to the multipiler
        PlayerPrefs.SetInt("pointsGoal",goalmult);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//reset everything 
    }

    public void FullReset(){
        PlayerPrefs.SetFloat("pointsMultiplier",1);
        PlayerPrefs.SetInt("pointsGoal",goal);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//reset everything
    }

    
}
