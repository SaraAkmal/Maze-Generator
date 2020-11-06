using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class LeftBtnMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    internal bool leftBtn = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        leftBtn = true;



    }

    public void OnPointerUp(PointerEventData eventData)
    {
        leftBtn = false;
    }
}
