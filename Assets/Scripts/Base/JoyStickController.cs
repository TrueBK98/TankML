using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Action onUp;

    public Image handle;
    private RectTransform joystickTransform;
    
    [SerializeField]
    private int dragMovementDistance = 30;
    [SerializeField]
    private int dragOffsetDistance = 100;

    public Vector3 Direction;

    void Awake()
    {
        joystickTransform = (RectTransform)handle.transform;
        Direction = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickTransform, eventData.position, null, out offset);
        offset = Vector2.ClampMagnitude(offset, dragOffsetDistance) / dragOffsetDistance;
        joystickTransform.anchoredPosition = offset * dragMovementDistance;
        Direction = offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickTransform.anchoredPosition = Vector2.zero;
        Direction = Vector3.zero;
        if (onUp != null)
        {
            onUp();
        }
    }
}
