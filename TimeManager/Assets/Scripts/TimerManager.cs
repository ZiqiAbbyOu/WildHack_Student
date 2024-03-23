using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    //public TaskSlot timerTaskSlot;

    public float initialTime;
    public int updatedTime;
    public bool timerRunning = false;
    public float remainingTime;
    public TextMeshProUGUI timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // timer counting down
        if (timerRunning)
        {
            remainingTime -= Time.deltaTime;

            int minuteLeft = Mathf.FloorToInt(remainingTime / 60);
            int secondLeft = Mathf.FloorToInt(remainingTime % 60);

            timerDisplay.text = string.Format("{0:00}:{1:00}", minuteLeft, secondLeft);

            if (remainingTime <= 0)
            {
                timerRunning = false;
                remainingTime = 0;
            }

        }


    }

    public void InitializeTimer(int time)
    {
        remainingTime = time * 60f;
        initialTime = remainingTime;
    }

    public void StartCounting()
    {
        timerRunning = true;
    }



}
