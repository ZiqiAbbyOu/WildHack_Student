using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    //Play Button
    public Button playButton;
    public Button pauseButton;
    public Button stopButton;

    //timer pointer
    public GameObject timerPointer;

    // ongoing task
    public TaskController onGoingTask;
    public Transform todoListTransform;
    public Transform finishedTransform;


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
            UpdateTimerPointer();

            if (remainingTime <= initialTime / 2)
            {
                UpdateEncouragement("Half Way Through! You Got This!");
            }

            if (remainingTime <= 0)
            {
                TimesUp();
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
        UpdateEncouragement("You've got this!");
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

    public void ResetTimer()
    {
        initialTime = 0;
        SetRemainingTimerToZero();
        ResetTimerPointer();
        TimerUpdate();
    }

    // stop the timer
    public void StopTimer()
    {
        timerRunning = false;
        SetRemainingTimerToZero();
        UpdateEncouragement("Waw, you done early?");
        EnableButtons();
        playButton.interactable = false;
        pauseButton.interactable = false;
        stopButton.interactable = false;

    }

    public void UpdateEncouragementFinishedYes()
    {
        UpdateEncouragement("Amazing!");
        DisableButtons();

        // Push to Finish List
        onGoingTask.MoveToContainer(finishedTransform);
        ResetTimer();
        
    }

    public void UpdateEncouragementFinishedNo()
    {
        UpdateEncouragement("It is ok, we will try it again later!");
        DisableButtons();

        // Push to Todo List
        onGoingTask.MoveToContainer(todoListTransform);
        ResetTimer();
    }



    public void EnableButtons()
    {
        yesButton.SetActive(true);
        noButton.SetActive(true);
    }

    public void DisableButtons()
    {
        yesButton.SetActive(false);
        noButton.SetActive(false);
        Debug.Log("Disabled buttons");
    }


    // Reach the time

    public void TimesUp()
    {
        UpdateEncouragement("Times Up! Have You Finished?");
        timerRunning = false;
        remainingTime = 0;
        TimerUpdate();
        EnableButtons();

        playButton.interactable = false;
        pauseButton.interactable = false;
        stopButton.interactable = false;
    }


    //Timer Pointer

    public void UpdateTimerPointer()
    {
        float elapsedTime = initialTime - remainingTime;
        if (elapsedTime <= initialTime)
        {
            float angle = Map(elapsedTime, 0, initialTime, 0, 180);
            timerPointer.transform.rotation = Quaternion.Euler(0, 0, -angle);
        }
    }

    public float Map(float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }

    public void ResetTimerPointer()
    {
        timerPointer.transform.rotation = Quaternion.Euler(0, 0, 0);
    }




}
