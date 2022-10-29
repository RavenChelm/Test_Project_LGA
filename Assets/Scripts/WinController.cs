using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    [SerializeField] GameObject GameField;
    [SerializeField] GameObject CanvasMenuController;
    [SerializeField] GameObject VictoryScreen;
    private List<Cell> AllCells = new List<Cell>();
    private bool green = false;
    private bool blue = false;
    private bool red = false;
    void Start()
    {
        for (int i = 0; i < GameField.transform.childCount; i++)
        {
            AllCells.Add(GameField.transform.GetChild(i).GetComponent<Cell>());
        }
    }
    void Win()
    {
        for (int i = 0; i < AllCells.Count; i = i + 5)
        {

            if (AllCells[i].ContentStorage.childCount > 0)
            {
                Debug.Log(AllCells[i].ContentStorage.GetChild(0).tag);
                if (AllCells[i].ContentStorage.GetChild(0).tag == "Red")
                {

                    red = true;
                }
                else
                {
                    red = false;
                    break;
                }
            }
            else
            {
                red = false;
                break;
            }
        }
        for (int i = 2; i < AllCells.Count; i = i + 5)
        {

            if (AllCells[i].ContentStorage.childCount > 0)
            {
                if (AllCells[i].ContentStorage.GetChild(0).tag == "Green")
                {

                    green = true;
                }
                else
                {
                    green = false;
                    break;
                }
            }
            else
            {
                green = false;
                break;
            }
        }
        for (int i = 4; i < AllCells.Count; i = i + 5)
        {
            if (AllCells[i].ContentStorage.childCount > 0)
            {
                if (AllCells[i].ContentStorage.GetChild(0).tag == "Blue")
                {

                    blue = true;
                }
                else
                {
                    blue = false;
                    break;
                }
            }
            else
            {
                blue = false;
                break;
            }

        }
        if (red && green && blue)
        {
            CanvasMenuController.SendMessage("MenuOn", VictoryScreen);
        }
    }
}

