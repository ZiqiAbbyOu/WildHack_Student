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

    

    // Start is called before the first frame update
    void Start()
    {
        //taskContainner = GameObject.Find("Task Container").transform;
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
        taskController.isInTodoList = isTodoList;


        // Initialize game timer if it is timer slot
        if (isTimeSlot)
        {
            TimerManager timerManager = GameObject.Find("Game Manager").GetComponent<TimerManager>();
            int.TryParse(taskController.timeInputField.text, out timerManager.initialTime);
            Debug.Log(timerManager.initialTime);
        }

    }
}
