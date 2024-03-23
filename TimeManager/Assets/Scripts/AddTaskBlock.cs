using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTaskBlock : MonoBehaviour
{
    public Transform contentTransform;
    public GameObject todoBlockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Create New Block In Content
    public void CreateNewTodoBlock()
    {
        Instantiate(todoBlockPrefab, contentTransform);
    }
}
