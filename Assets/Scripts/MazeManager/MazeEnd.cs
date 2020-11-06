using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MazeEnd : MonoBehaviour
{



    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StaticInformation.win = true;
            SceneManager.LoadScene(2);
        }
    }






}
