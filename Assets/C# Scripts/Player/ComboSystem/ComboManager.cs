using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComboManager : MonoBehaviour
{
    private const float defaultTimeToKill = 10f;
    private float timeToKill = 10f;
    private int combo = 0;
    private int killForCombo = 1;
    private int killCount = 0;

    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text comboTxt;

    private void Update(){
        timeToKill -= Time.deltaTime;
        timeToKill = Mathf.Clamp(timeToKill, 0f, defaultTimeToKill);
        slider.value = timeToKill;
        if(timeToKill <= 0f){
            ComboEnd();
        }
    }

    public void ComboKill(){
        killCount++;
        if(killCount >= killForCombo){
            killForCombo *= 2;
            Debug.Log(killForCombo);
            //ApplyComboBuff()
            killCount = 0;
            combo++;
            comboTxt.text = (combo + "x");
            timeToKill = defaultTimeToKill - (0.5f * combo);
            slider.maxValue = timeToKill; 
            slider.value = timeToKill;
        }
    }

    public void ComboEnd(){
        timeToKill = 7.5f;
        combo = 0;
        killForCombo = 1;
        killCount = 0;
        comboTxt.text = (combo + "x");
    }
}
