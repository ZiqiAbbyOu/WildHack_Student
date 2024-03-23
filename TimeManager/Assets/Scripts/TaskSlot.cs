using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TaskSlot : MonoBehaviour, IDropHandler
{
    public Transform taskContainner;
    public bool isExlusive;

    

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
    }
}
