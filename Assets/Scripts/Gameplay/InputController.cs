using System;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnDragEvent(float delta);

public class InputController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public event OnDragEvent onDragEvent;
    public event Action onPointerDown;
    public event Action onPointerUp;


    public void OnDrag(PointerEventData eventData)
    {
        onDragEvent?.Invoke(eventData.delta.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUp?.Invoke();
    }
}