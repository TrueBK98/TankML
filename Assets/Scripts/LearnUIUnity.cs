using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LearnUIUnity : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    public Image handle;
    Vector3 originalHandlePos;

    void Start()
    {
        originalHandlePos = handle.transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        handle.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        handle.transform.position = originalHandlePos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        handle.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        handle.transform.position = eventData.position;
    }
}
