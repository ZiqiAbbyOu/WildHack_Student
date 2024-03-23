using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TaskController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject block;

    // Delete Block
    public void DeleteBlock()
    {
        Destroy(block);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
