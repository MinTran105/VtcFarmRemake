using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DayAndNightManager : MonoBehaviour
{
    public Text timeInGameText;
    //time speed up
    public float dayMutiplier = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //create Time in game by real time
        DateTime realTime = DateTime.Now;
        float realSecondInday = (realTime.Hour *3600) + (realTime.Minute*60) + realTime.Second;
        //speed up % 24h(86400 seconds)
        realSecondInday *= dayMutiplier % 86400;

        int gameHour = Mathf.FloorToInt(realSecondInday / 3600);
        int gameMinute = Mathf.FloorToInt(realSecondInday % 3600 / 60);
        //format time text
        timeInGameText.text = string.Format("{0:00}:{1:00}", gameHour, gameMinute);
    }
}
