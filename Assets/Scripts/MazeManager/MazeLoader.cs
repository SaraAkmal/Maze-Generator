using UnityEngine;
using System.Collections;
using System;

public class MazeLoader : MonoBehaviour
{
    private int mazeRows, mazeColumns;
    public GameObject wall;
    public GameObject ground;
    public GameObject ceiling;
    public GameObject mazeEnd;
    public Camera aboveCamera;

    public float size = 2f;

    private MazeCell[,] mazeCells;


    private void levelOfChoice(int choice)
    {
        if (choice == 0)
        {
            GetComponent<TimerController>().secondsLeft = 25;
            GetComponent<TimerController>().minutesLeft = 1;
            mazeRows = 10;
            mazeColumns = 6;
            aboveCamera.fieldOfView = 67;
        }
        else if (choice == 1)
        {
            GetComponent<TimerController>().secondsLeft = 25;
            GetComponent<TimerController>().minutesLeft = 2;
            mazeRows = 12;
            mazeColumns = 8;
            aboveCamera.fieldOfView = 85;
            aboveCamera.transform.position = new Vector3(33.9f, 55.24f, 21.4f);


        }
        else if (choice == 2)
        {
            GetComponent<TimerController>().secondsLeft = 25;
            GetComponent<TimerController>().minutesLeft = 3;
            mazeRows = 11;
            mazeColumns = 9;
            aboveCamera.fieldOfView = 89;
            aboveCamera.transform.position = new Vector3(27.4f, 55.24f, 23.7f);
        }
        else
        {
            mazeRows = 7;
            mazeColumns = 5;
        }
    }


    internal void startGame()
    {
        levelOfChoice(StaticInformation.choice);
        InitializeMaze();
        MazeAlgorithm ma = new HuntAndKillMazeAlgorithm(mazeCells);
        ma.CreateMaze();
    }
    private void InitializeMaze()
    {
        //int row = 0;
        //int column = 0;

        int c = 0;
        int r = 0;

        mazeCells = new MazeCell[mazeRows, mazeColumns];
        GameObject Floor = Instantiate(ground, new Vector3(-2.77f + ((mazeRows * 6) / 2), -3.37f, -2.85f + ((mazeColumns * 6) / 2)), Quaternion.Euler(90, 0, 0));
        Floor.transform.localScale = new Vector3(mazeRows * 6, 6 * mazeColumns, 0.6f);

        GameObject Ceiling = Instantiate(ceiling, new Vector3(-2.77f + ((mazeRows * 6) / 2), 3.4f, -2.85f + ((mazeColumns * 6) / 2)), Quaternion.Euler(90, 0, 0));
        Ceiling.transform.localScale = new Vector3(mazeRows * 6, 6 * mazeColumns, 0.6f);

        for (r = 0; r < mazeRows; r++)
        {
            for (c = 0; c < mazeColumns; c++)
            {
                mazeCells[r, c] = new MazeCell();

                //mazeCells[r, c].floor = Instantiate(ground, new Vector3(r * size, -(size / 2f), c * size), Quaternion.identity) as GameObject;
                //mazeCells[r, c].floor.name = "Floor " + r + "," + c;
                //mazeCells[r, c].floor.transform.Rotate(Vector3.right, 90f);

                if (c == 0)
                {
                    mazeCells[r, c].westWall = Instantiate(wall, new Vector3((r * size), 0, (c * size) - (size / 2f)), Quaternion.identity) as GameObject;
                    mazeCells[r, c].westWall.name = "West Wall " + r + "," + c;
                }

                mazeCells[r, c].eastWall = Instantiate(wall, new Vector3((r * size), 0, (c * size) + (size / 2f)), Quaternion.identity) as GameObject;
                mazeCells[r, c].eastWall.name = "East Wall " + r + "," + c;

                if (r == 0)
                {
                    mazeCells[r, c].northWall = Instantiate(wall, new Vector3((r * size) - (size / 2f), 0, c * size), Quaternion.identity) as GameObject;
                    mazeCells[r, c].northWall.name = "North Wall " + r + "," + c;
                    mazeCells[r, c].northWall.transform.Rotate(Vector3.up * 90f);
                }

                mazeCells[r, c].southWall = Instantiate(wall, new Vector3((r * size) + (size / 2f), 0, c * size), Quaternion.identity) as GameObject;
                mazeCells[r, c].southWall.name = "South Wall " + r + "," + c;
                mazeCells[r, c].southWall.transform.Rotate(Vector3.up * 90f);

            }


        }
        Quaternion myRotation = Quaternion.identity;
        myRotation.eulerAngles = new Vector3(90f, 0f, 0f);

        Instantiate(mazeEnd, new Vector3((r - 1) * size, -(size / 2f), (c - 1) * size), myRotation);

    }

}
