using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMaze : MonoBehaviour
{

    [SerializeField] GameObject MazeGen;

    void Start()
    {
        MazeGen.GetComponent<MazeLoader>().startGame();
        MazeGen.GetComponent<TimerController>().StartTimer = true;
    }

}
