using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    [SerializeField] Text countDownText;
    internal int secondsLeft = 0;
    internal int minutesLeft = 0;
    private bool TimerTakeERunning = false;
    internal bool StartTimer = false;

    void Start()
    {
        if (secondsLeft < 10)
            countDownText.text = minutesLeft + ":0" + secondsLeft;
        else
            countDownText.text = minutesLeft + ":" + secondsLeft;
    }

    void Update()
    {
        if (StartTimer)
        {
            if (!TimerTakeERunning && secondsLeft > 0)
                StartCoroutine(TimerTake());

            else if (!TimerTakeERunning && secondsLeft == 0 && minutesLeft == 0)
            {
                StaticInformation.win = false;
                SceneManager.LoadScene(2);
            }
        }
        StopCoroutine(TimerTake());
    }

    IEnumerator TimerTake()
    {
        if (TimerTakeERunning) yield break;
        TimerTakeERunning = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;

        if (secondsLeft < 10)
            countDownText.text = minutesLeft + ":0" + secondsLeft;
        else
            countDownText.text = minutesLeft + ":" + secondsLeft;

        if (secondsLeft == 0 && minutesLeft > 0)
        {
            minutesLeft -= 1;
            secondsLeft = 60;
        }

        TimerTakeERunning = false;
    }
}
