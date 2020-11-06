using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LookAboveBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool LookUp = false;
    [SerializeField] GameObject cameraUp;
    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject canvas;



    void Start()
    {

    }


    void Update()
    {

    }

    private void playerCameraFunction()
    {

        playerCamera.GetComponent<Camera>().enabled = true;
        cameraUp.GetComponent<Camera>().enabled = false;
        playerCamera.GetComponent<PlayerManager>().stopMovingAboveCamera = false;
        canvas.GetComponent<CanvasGroup>().alpha = 1;

    }
    private void LookUpFunction()
    {
        canvas.GetComponent<CanvasGroup>().alpha = 0;
        playerCamera.GetComponent<Camera>().enabled = false;
        cameraUp.GetComponent<Camera>().enabled = true;
        playerCamera.GetComponent<PlayerManager>().stopMovingAboveCamera = true;

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        LookUpFunction();
        Invoke("playerCameraFunction", 3f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

}
