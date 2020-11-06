using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] float rotateSpeedModifier = 0.1f;
    [SerializeField] private float movementSpeed;

    private bool tap = false;
    private bool swipeLeft, swipeRight, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;
    private CharacterController charController;
    [SerializeField] GameObject wallObject;
    [SerializeField] GameObject MoveFasterBtn;

    [SerializeField] GameObject LeftSwipeAnimator;
    [SerializeField] GameObject RightSwipeAnimator;

    //Rotation
    private Quaternion rotationY;
    float yAngle = 0;

    private bool stopMoving = false;
    internal bool stopMovingAboveCamera = false;
    internal bool startFootPrint = false;
    internal bool foot = false;

    private bool swipeLeftBool = false;
    private bool swipeRightBool = false;

    private bool IsNearWallCollider = false;



    Ray ray;
    RaycastHit hitInfo;
    private void Start()
    {
        charController = gameObject.GetComponent<CharacterController>();
    }


    private void Update()
    {

        print(stopMoving);
        IsNearWallColliderLeft();
        IsNearWallColliderRight();
        Swiping();
        SwipeRightFunction(swipeRight);
        SwipeLeftFunction(swipeLeft);
        SwipeDownFunction(swipeDown);
        Moving();
        fullRotation();
        //TapFunction(tap);
    }
    //private void IsNearWall()
    //{

    //    if (rayCastWallInformation(Vector3.left))
    //    {
    //        print("1");
    //        RotateLeft();
    //        IsNearWallCollider = true;
    //        return;
    //    }
    //    else if (rayCastWallInformation(Vector3.right))
    //    {
    //        print("2");
    //        RotateRight();
    //        IsNearWallCollider = true;
    //        return;
    //    }
    //    else if (rayCastWallInformation(-Vector3.back))
    //    {
    //        print("3");
    //        RotateBack();
    //        IsNearWallCollider = true;
    //        return;
    //    }
    //    else
    //        IsNearWallCollider = false;

    //}

    //private bool rayCastWallInformation(Vector3 vectorDirection)
    //{
    //    Vector3 direction = transform.TransformDirection(vectorDirection);

    //    ray = new Ray(transform.position, direction);
    //    if (Physics.Raycast(ray, out hitInfo, 0.05f))
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        return true;
    //    }

    //}



    public void MoveFaster()
    {
        if (MoveFasterBtn.GetComponent<MoveFaster>().moveFasterBtn)
            movementSpeed = 4.5f;
        else
            movementSpeed = 2f;
    }

    internal bool IsNearWallColliderRight()
    {
        Vector3 direction = transform.TransformDirection(Vector3.right);

        ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out hitInfo, 4f))
        {
            RightSwipeAnimator.GetComponent<Image>().color = Color.red;
            RightSwipeAnimator.GetComponent<SwipeBtnAnimation>().ResetRightArrowPosition();
            return true;
        }
        else
        {
            RightSwipeAnimator.GetComponent<SwipeBtnAnimation>().RightBtnAnimation();
            RightSwipeAnimator.GetComponent<Image>().color = Color.green;

            if (swipeRightBool)
            {
                RotateRight();
                swipeRightBool = false;
            }
            return false;
        }

    }

    internal bool IsNearWallColliderLeft()
    {
        Vector3 direction = transform.TransformDirection(-Vector3.right);
        ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out hitInfo, 4f))
        {
            // Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            LeftSwipeAnimator.GetComponent<SwipeBtnAnimation>().ResetLeftArrowPosition();
            LeftSwipeAnimator.GetComponent<Image>().color = Color.red;
            return true;
        }
        else
        {
            LeftSwipeAnimator.GetComponent<SwipeBtnAnimation>().LeftBtnAnimation();
            LeftSwipeAnimator.GetComponent<Image>().color = Color.green;
            //Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
            //new
            if (swipeLeftBool)
            {
                RotateLeft();
                swipeLeftBool = false;
            }
            return false;
        }
    }
    internal bool IsNearWallColliderBack()
    {
        Vector3 direction = transform.TransformDirection(Vector3.back);
        ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out hitInfo, 1.5f))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ResetBooleansQueue()
    {
        swipeLeftBool = false;
        swipeRightBool = false;
    }

    private void Swiping()
    {
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //stopMoving = false;
            tap = false;
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                //stopMoving = false;
                tap = false;
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }

            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }

        }

        //Did we cross the distance?
        if (swipeDelta.magnitude > 100)
        {
            if (swipeRight || swipeLeft || swipeDown)
                return;

            tap = false;

            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                tap = false;
                //Left
                if (x < 0)
                {
                    if (IsNearWallColliderLeft())
                    {
                        //swipeLeftBool for queue
                        swipeLeftBool = true;
                        swipeLeft = false;
                    }
                    else
                    {
                        stopMoving = true;
                        RotateLeft();

                    }
                }
                //Right
                else if (x > 0)
                {
                    if (IsNearWallColliderRight())
                    {
                        swipeRightBool = true;
                        swipeRight = false;
                    }
                    else
                    {
                        stopMoving = true;
                        RotateRight();

                    }
                }
            }

            else
            {   //Swiping Down
                if (y < 0)
                {
                    if (!IsNearWallColliderBack())
                    {
                        RotateBack();
                    }
                }
            }
            Reset();
        }


    }

    private void fullRotation()
    {

        if (transform.rotation.eulerAngles.y > (rotationY.eulerAngles.y - 1) && transform.rotation.eulerAngles.y < (rotationY.eulerAngles.y + 1))
        {
            swipeRight = false;
            swipeLeft = false;
            swipeDown = false;
            stopMoving = false;
            IsNearWallCollider = false;
        }
    }

    internal void RotateLeft()
    {
        ResetBooleansQueue();
        swipeLeft = true;
        yAngle -= 90f;
        rotationY = Quaternion.Euler(0, yAngle, 0);
    }

    internal void RotateRight()
    {
        ResetBooleansQueue();
        swipeRight = true;
        yAngle += 90f;
        rotationY = Quaternion.Euler(0, yAngle, 0);
    }

    internal void RotateBack()
    {
        ResetBooleansQueue();
        swipeDown = true;
        yAngle += 180f;
        rotationY = Quaternion.Euler(0, yAngle, 0);
    }

    //to reach full rotation
    void SwipeRightFunction(bool swipeRight)
    {
        if (swipeRight)
        {
            rotationY = Quaternion.Euler(0, yAngle, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationY, Time.deltaTime * rotateSpeedModifier);
        }

    }
    void SwipeLeftFunction(bool swipeLeft)
    {
        if (swipeLeft)
        {
            rotationY = Quaternion.Euler(0, yAngle, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationY, Time.deltaTime * rotateSpeedModifier);
        }

    }
    void SwipeDownFunction(bool swipeDown)
    {
        if (swipeDown)
        {
            rotationY = Quaternion.Euler(0, yAngle, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationY, Time.deltaTime * rotateSpeedModifier);
            stopMoving = true;
        }
    }


    private void Moving()
    {
        if (stopMoving || stopMovingAboveCamera)
        {
            //Doesnt move
            foot = false;

        }
        else
        {
            foot = true;
            //transform.position += transform.forward * Time.deltaTime * movementSpeed;
            charController.Move(transform.forward * Time.deltaTime * movementSpeed);
        }
    }



    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

}