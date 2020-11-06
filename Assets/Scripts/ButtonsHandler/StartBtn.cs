using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject choices;



    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < 3; i++)
        {
            if (choices.GetComponent<LevelManager>().choice[i] == 1)
            {
                StaticInformation.choice = i;
                SceneManager.LoadScene(1);
            }
        }



    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
