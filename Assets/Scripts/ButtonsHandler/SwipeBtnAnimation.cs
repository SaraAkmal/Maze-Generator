using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeBtnAnimation : MonoBehaviour
{
    [SerializeField] private float minXRange;
    [SerializeField] private float maxXRange;
    private int movementSpeed = 10;


    internal void LeftBtnAnimation()
    {

        if (transform.localPosition.x <= minXRange)
        {
            Vector3 position = transform.localPosition;
            position.x = maxXRange;
            transform.localPosition = position;
        }
        else if (transform.localPosition.x > minXRange)
        {
            Vector3 position = transform.localPosition;
            position.x -= 10f * Time.deltaTime * movementSpeed;
            transform.localPosition = position;

        }

    }

    internal void RightBtnAnimation()
    {

        if (transform.localPosition.x >= maxXRange)
        {
            Vector3 position = transform.localPosition;
            position.x = minXRange;
            transform.localPosition = position;
        }

        else if (transform.localPosition.x < maxXRange)
        {
            Vector3 position = transform.localPosition;
            position.x += 10f * Time.deltaTime * movementSpeed;
            transform.localPosition = position;

        }

    }

    internal void ResetRightArrowPosition()
    {
        Vector3 position = transform.localPosition;
        if (position.x <= maxXRange)
        {
            position.x += 10f * Time.deltaTime * movementSpeed;
            transform.localPosition = position;
        }



    }

    internal void ResetLeftArrowPosition()
    {
        Vector3 position = transform.localPosition;
        if (position.x >= minXRange)
        {
            position.x -= 10f * Time.deltaTime * movementSpeed;
            transform.localPosition = position;
        }


    }
}
