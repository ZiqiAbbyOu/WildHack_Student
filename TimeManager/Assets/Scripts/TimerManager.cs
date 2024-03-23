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

    //Updating Text and image 
    public TextMeshProUGUI timerDisplayTMP;
    public TextMeshProUGUI encouragementTMP;

    //Selection Buttons
    public GameObject yesButton;
    public GameObject noButton;

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

            TimerUpdate();

            if (remainingTime <= initialTime / 2)
            {
                UpdateEncouragement("Half Way Through! You Got This!");
            }

            if (remainingTime <= 0)
            {
                UpdateEncouragement("Times Up! You Made It!");
                timerRunning = false;
                remainingTime = 0;
                TimerUpdate();
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


    public void UpdateEncouragement(string log)
    {
        encouragementTMP.text = log;
    }

    public void TimerUpdate()
    {
        int minuteLeft = Mathf.FloorToInt(remainingTime / 60);
        int secondLeft = Mathf.FloorToInt(remainingTime % 60);

        timerDisplayTMP.text = string.Format("{0:00}:{1:00}", minuteLeft, secondLeft);
    }

    public void PauseTimer()
    {
        timerRunning = false;
        UpdateEncouragement("It's OK! Just Take A Break!");

    }


    
    public void SetRemainingTimerToZero()
    {
        remainingTime = 0.0f;

    }

    // stop the timer
    public void StopTimer()
    {
        timerRunning = false;
        SetRemainingTimerToZero();
        UpdateEncouragement("Waw, you done early?");


        // It is ok, we will try it again later!
        // Great Job! (And move it to the Finished list)
    }


}
