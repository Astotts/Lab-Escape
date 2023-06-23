using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class ResetControl : MonoBehaviour
{

    public float multipilerAmount = 2;
    public int count = 0;

    [SerializeField] private TMP_Text Txt;

    void Start(){
        if(!PlayerPrefs.HasKey("pointsMultiplier")){
            PlayerPrefs.SetFloat("pointsMultiplier",1);//default
        }
        //Txt.text = PlayerPrefs.GetFloat("pointsMultiplier").ToString();//for testing
    }


    public void GameReset(){
        //stuff that needs to save

        //unlock fish weapons

        //bonus multiplier
        var mult = PlayerPrefs.GetFloat("pointsMultiplier");
        mult = mult * multipilerAmount;
        PlayerPrefs.SetFloat("pointsMultiplier",mult);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//reset everything 
    }

    public void FullReset(){
        PlayerPrefs.SetFloat("pointsMultiplier",1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//reset everything
    }

    
}
