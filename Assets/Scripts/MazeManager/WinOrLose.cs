using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinOrLose : MonoBehaviour
{
    [SerializeField] AudioClip WinAudio;
    [SerializeField] AudioClip LoseAudio;
    void Start()
    {
        if (StaticInformation.win)
        {
            gameObject.GetComponent<Text>().text = "Winner!";
            gameObject.GetComponent<Text>().color = new Color(0.2917853f, 0.7830189f, 0.2992217f);
            gameObject.GetComponent<AudioManager>().Audio = WinAudio;
            gameObject.GetComponent<AudioManager>().playAudio();
        }
        else
        {

            gameObject.GetComponent<Text>().text = "You lost!";
            gameObject.GetComponent<Text>().color = new Color(0.7830189f, 0.2317549f, 0.1883677f);
            gameObject.GetComponent<AudioManager>().Audio = LoseAudio;
            gameObject.GetComponent<AudioManager>().playAudio();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
