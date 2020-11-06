using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FootprintBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject player;
    [SerializeField] private GameObject footPrint;
    private float timeForFootprint = 0;
    List<GameObject> footprintList;

    private bool generating = false;


    void Start()
    {

        footprintList = new List<GameObject>();
    }
    void Update()
    {
        GenerateFootprints();



    }

    private void GenerateFootprints()
    {
        if (generating)
        {
            InstantiateFootPrint();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        generating = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        Invoke("RemoveFootprints", 15f);
    }

    //FootPrint IMPORTANT

    private void InstantiateFootPrint()
    {
        //change player.GetComponent script, foot was a boolean checking if its moving
        if (player.GetComponent<PlayerManager>().foot && (Time.time - timeForFootprint > 0.8f) && player.GetComponent<PlayerManager>().startFootPrint)
        {
            Quaternion myRotation = Quaternion.identity;
            myRotation.eulerAngles = new Vector3(0f, player.transform.rotation.eulerAngles.y, 0f);
            footprintList.Add(Instantiate(footPrint, new Vector3(player.transform.position.x - 2, -2.979f, player.transform.position.z), myRotation));
            timeForFootprint = Time.time;
            print("YO");
        }

    }


    private void RemoveFootprints()
    {
        generating = false;
        //print(footprintList.Count);
        for (int i = 0; i < footprintList.Count; i++)
        {
            print(i);
            Destroy(footprintList[i]);

        }
        footprintList.Clear();
    }
}
