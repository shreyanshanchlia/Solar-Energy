using UnityEngine;
using UnityEngine.Events;

public class Draggable : MonoBehaviour
{
    [SerializeField] private bool draggableOnAwake = false;
    [SerializeField] private float snappingDistance;
    private bool isDragging = false;

    [SerializeField] private UnityEvent onDragComplete;
    
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
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                transform.Snap(snappingDistance);
                onDragComplete.Invoke();
            }
        }
    }

    public void DisableDrag()
    {
        isDragging = false;
        transform.Snap(snappingDistance);
        enabled = false;
    }

    private void UpdatePosition()
    {
        transform.position = (Vector2)Cam.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag() => isDragging = true;
}
