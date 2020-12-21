using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// This class toggles the Player movement speed.
/// </summary>
public class MoveFaster : MonoBehaviour, IPointerDownHandler
{
    internal bool moveFasterBtn = false;
    private string slow = "1x";
    private string fast = "2x";


    public void OnPointerDown(PointerEventData eventData)
    {
        moveFasterBtn = !moveFasterBtn;
        toggleText(moveFasterBtn);
    }

    private void toggleText(bool moveFasterBtn)
    {
        if (moveFasterBtn)
            transform.GetChild(0).GetComponent<Text>().text = slow;
        else
            transform.GetChild(0).GetComponent<Text>().text = fast;

    }
}