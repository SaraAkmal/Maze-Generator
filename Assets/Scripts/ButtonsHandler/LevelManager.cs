using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField] Sprite normalBtn;
    [SerializeField] Sprite greenBtn;

    private int EmptySelection = 0;
    private int lastChecked = 0;


    internal int[] choice = { 0, 0, 0 };
    void Start()
    {
        CheckBtn(0);
    }
    void Update()
    {
        chooseLevel();
    }


    public void chooseLevel()
    {
        EmptySelection = 0;
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<LevelBtn>().choosenLevel)
                {
                    CheckBtn(i);
                    lastChecked = i;
                }
                else
                {
                    UnCheckBtn(i);
                    EmptySelection++;
                }
            }
            if (EmptySelection == 3)
            {
                EmptySelection = 0;
                CheckBtn(lastChecked);
            }
        }
    }

    private void CheckBtn(int buttonNum)
    {
        choice[buttonNum] = 1;
        //transform.GetChild(buttonNum).localScale = Vector2.Lerp(transform.GetChild(buttonNum).localScale, new Vector2(1.1f, 1.1f), 0.7f);
        transform.GetChild(buttonNum).localScale = new Vector3(1.1f, 1.1f, 1.1f);
        transform.GetChild(buttonNum).GetComponent<Image>().color = new Color(0.6313726f, 0.9490196f, 0.7522463f);
        transform.GetChild(buttonNum).GetComponent<Image>().sprite = greenBtn;
    }


    private void UnCheckBtn(int buttonNum)
    {
        choice[buttonNum] = 0;
        transform.GetChild(buttonNum).GetComponent<LevelBtn>().choosenLevel = false;
        transform.GetChild(buttonNum).localScale = Vector2.Lerp(transform.GetChild(buttonNum).localScale, new Vector2(1, 1), 0.8f);
        transform.GetChild(buttonNum).GetComponent<Image>().color = new Color(0.631052f, 0.6792551f, 0.8207547f);
        transform.GetChild(buttonNum).GetComponent<Image>().sprite = normalBtn;
    }





}