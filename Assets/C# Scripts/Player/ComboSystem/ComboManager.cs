using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    private const float defaultTimeToKill = 10f;
    private float timeToKill = 10f;
    public int combo = 0;
    public int killForCombo = 1;
    public int killCount = 0;

    private void Update(){
        timeToKill -= Time.deltaTime;
        timeToKill = Mathf.Clamp(defaultTimeToKill, 0f);
        if(timeToKill <= 0f){
            ComboEnd();
        }
    }

    public void ComboKill(){
        killCount++;
        if(killCount == killForCombo){
            killForCombo = Mathf.CeilToInt(Mathf.Pow(killForCombo, 1.5f));
            //ApplyComboBuff()
            killCount = 0;
            combo++;
            timeToKill = defaultTimeToKill - (0.5f * combo);
        }
    }

    public void ComboEnd(){
        timeToKill = 7.5f;
        combo = 0;
        killForCombo = 1;
        killCount = 0;
    }
}
