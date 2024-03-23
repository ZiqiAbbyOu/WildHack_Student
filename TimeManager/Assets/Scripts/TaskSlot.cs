using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TaskSlot : MonoBehaviour, IDropHandler
{
    public Transform taskContainner;
    public bool isExlusive;
    public bool isTodoList;
    public bool isTimeSlot;
    public bool isDoneList;
    public TimerManager timerManager;

    

    // Start is called before the first frame update
    void Start()
    {
        //taskContainner = GameObject.Find("Task Container").transform;
        timerManager = GameObject.Find("Game Manager").GetComponent<TimerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        TaskController taskController = eventData.pointerDrag.GetComponent<TaskController>();
        if ((taskController != null) && !(isExlusive && taskContainner.childCount > 0))
        {
            taskController.transform.SetParent(taskContainner);
            taskController.transform.position = taskContainner.position;
            taskController.startPosition = taskContainner.position;
            taskController.originalParent = taskContainner;
        }

        // Set task controller bool isTodoList

        if (isTodoList)
        {
            taskController.isInTodoList = isTodoList;
            timerManager.UpdateEncouragement("Move Your Task Here to Begin!");
        }


        //if it is timer slot, Initialize game timer 
        if (isTimeSlot)
        {
            // initialize game timer
            //TimerManager timerManager = GameObject.Find("Game Manager").GetComponent<TimerManager>();
            int.TryParse(taskController.timeInputField.text, out int initialTime);
            timerManager.InitializeTimer(initialTime);
            timerManager.TimerUpdate();
            //Debug.Log("Initial Time: " + initialTime +  "Time Manager time: " + timerManager.remainingTime);

            // Update Encouragement
            timerManager.UpdateEncouragement("Now Click The Play Button Below To Start The Timer!");
        }
        else // stop and initialize game timer if it is not timer slot
        {
            //TimerManager timerManager = GameObject.Find("Game Manager").GetComponent<TimerManager>();
            timerManager.timerRunning = false;
            timerManager.InitializeTimer(0);
            timerManager.TimerUpdate();
        }

        // if it is Done list, Update Encouragement
        if (isDoneList)
        {
            //TimerManager timerManager = GameObject.Find("Game Manager").GetComponent<TimerManager>();
            timerManager.UpdateEncouragement("Congratulations! You Made It!");

        }

    }
}
