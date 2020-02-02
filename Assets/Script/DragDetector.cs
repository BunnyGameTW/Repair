using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDetector : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int scale = 100;

    [NonSerialized]
    public bool IsDragable = false;
    [NonSerialized]
    public Action shakeDelegate = null;

    [SerializeField]
    private Scrollbar scrollbar;
    private float scrollbarSize;
    private float mouseX;
    private Vector3 screenPoint;
    private Vector3 offset;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        if (IsDragable)    // Only do if IsDraggable == true
        {
            if (shakeDelegate != null)
            {
                shakeDelegate.Invoke();
            }
            Debug.Log(IsDragable);
            mouseX = Input.mousePosition.x;
            scrollbarSize = scrollbar.size;
            //screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        if (IsDragable)    // Only do if IsDraggable == true
        {
            Debug.Log(IsDragable);
            float offset = (Input.mousePosition.x - mouseX) / scale;
            scrollbar.size = scrollbarSize + offset;
            //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); // hardcode the y and z for your use

            //Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            //transform.position = curPosition;
        }
    }

    /*void OnMouseDown()
    {
        Debug.Log("OnMouseDown");

        if (IsDragable)    // Only do if IsDraggable == true
        {
            mouseX = Input.mousePosition.x;
            scrollbarSize = scrollbar.size;
            //screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
        if (IsDragable)    // Only do if IsDraggable == true
        {
            float offset = (Input.mousePosition.x - mouseX) / 100;
            scrollbar.size = scrollbarSize + offset;
            //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); // hardcode the y and z for your use

            //Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            //transform.position = curPosition;
        }
    }*/






    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
