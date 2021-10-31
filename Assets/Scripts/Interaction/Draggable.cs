using System;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private bool draggableOnAwake = false;
    private bool isDragging = false;
    
    private void Start()
    {
        if (draggableOnAwake)
        {
            isDragging = true;
            UpdatePosition();
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            UpdatePosition();
            if (Input.GetMouseButtonUp(0)) isDragging = false;
        }
    }

    void UpdatePosition()
    {
        this.transform.position = (Vector2)Cam.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag() => isDragging = true;
}
