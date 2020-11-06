using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ExitBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{



    public void OnPointerDown(PointerEventData eventData)
    {
        Application.Quit();


    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
