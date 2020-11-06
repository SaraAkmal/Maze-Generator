using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    internal bool choosenLevel = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        choosenLevel = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        choosenLevel = false;
    }
}
