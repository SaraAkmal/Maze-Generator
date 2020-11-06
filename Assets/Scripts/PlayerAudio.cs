using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    [SerializeField] AudioClip music;

    public void playMusic()
    {
        gameObject.GetComponent<AudioSource>().clip = music;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
