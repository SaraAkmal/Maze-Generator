using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RetryBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{



    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(0);


    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
