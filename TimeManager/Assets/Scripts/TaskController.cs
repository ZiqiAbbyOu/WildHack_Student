using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TaskController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IDropHandler
{
    public RectTransform rectTransform;
    public GameObject block;
    public Vector3 startPosition;
    public Transform originalParent;
    public Transform backgroundParent;
    [SerializeField] Canvas canvas;

    private void Start()
    {
        backgroundParent = GameObject.Find("Background").transform;
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    // Delete Block
    public void DeleteBlock()
    {
        Destroy(block);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        startPosition = transform.position;
        originalParent = transform.parent;
        transform.SetParent(backgroundParent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //Debug.Log("Begin Drag");


        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = Input.mousePosition;
        //throw new System.NotImplementedException();
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;


        //Debug.Log("On Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        transform.position = startPosition;
        transform.SetParent(originalParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //throw new System.NotImplementedException();

        Debug.Log("End Drag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On Pointer Down");
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
