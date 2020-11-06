using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] internal AudioClip Audio;


    public void playAudio()
    {
        gameObject.GetComponent<AudioSource>().clip = Audio;
        gameObject.GetComponent<AudioSource>().Play();
    }

}
