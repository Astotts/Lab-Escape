using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComboManager
{
    private const float defaultTimeToKill = 10f;
    private static float timeToKill = 10f;
    public static int combo = 0;
    public static int killForCombo = 1;
    public static int killCount = 0;

    public static void ComboKill(){
        killCount++;
        if(killCount == killForCombo){
            killForCombo = Mathf.CeilToInt(Mathf.Pow(killForCombo, 1.5f));
            //ApplyComboBuff()
            killCount = 0;
            combo++;
            timeToKill = defaultTimeToKill - (0.5f * combo);
        }
    }

    public static void ComboEnd(){
        timeToKill = 7.5f;
        combo = 0;
        killForCombo = 1;
        killCount = 0;
    }
}
