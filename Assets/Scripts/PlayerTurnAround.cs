using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnAround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "wall")
        {

            if (gameObject.transform.parent.GetComponent<PlayerManager>().IsNearWallColliderRight() && gameObject.transform.parent.GetComponent<PlayerManager>().IsNearWallColliderLeft())
            {
                gameObject.transform.parent.GetComponent<PlayerManager>().RotateBack();
                print("back");
            }
            else if (gameObject.transform.parent.GetComponent<PlayerManager>().IsNearWallColliderRight())
            {
                gameObject.transform.parent.GetComponent<PlayerManager>().RotateLeft();
                print("left");
            }
            else
            {
                gameObject.transform.parent.GetComponent<PlayerManager>().RotateRight();
                print("right");
            }



        }
    }
}
