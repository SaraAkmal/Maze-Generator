using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool musicPlaying = true;
    [SerializeField] private GameObject player;
    [SerializeField] private Image musicBtnImage;
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOFF;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (musicPlaying == false)
        {
            musicPlaying = true;
            player.gameObject.GetComponent<AudioSource>().Play();
            musicBtnImage.sprite = musicOn;

        }
        else
        {
            musicPlaying = false;
            player.gameObject.GetComponent<AudioSource>().Pause();
            musicBtnImage.sprite = musicOFF;
        }


    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}

