using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimerTaskSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        TaskController taskController = eventData.pointerDrag.GetComponent<TaskController>();
        if (taskController != null)
        {
            taskController.transform.SetParent(transform);
            taskController.transform.position = transform.position;
            taskController.startPosition = transform.position;
            taskController.originalParent = transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
