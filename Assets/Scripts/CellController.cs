using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#nullable enable
public class CellController : MonoBehaviour
{
    private List<Cell> SelectNeighbours = new List<Cell>();
    private GameObject? CurrentCellObj;
    private GameObject? TargetCellObj;
    private Cell? CurrentCell;
    private Cell? TargetCell;
    [SerializeField] private GameObject WinContoroller;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject hitObj;

            if (RaycastUtilities.PointerIsOverUI(Input.mousePosition, out hitObj))
            {
                //logic start here
                if (CurrentCellObj == null) //case __Cell_Not_Select
                {
                    OffBackLightNeighbour();
                    (CurrentCellObj, CurrentCell) = SelectCell(hitObj);
                    if (SelectNeighbours.Count == 0)
                        SetParamsToNull();
                }
                else    //Case ___Cell_Select
                {
                    (TargetCellObj, TargetCell) = SelectNeighbourCell(hitObj);

                    if (TargetCell != null)
                    {
                        if (SelectNeighbours.Contains(TargetCell))
                        {

                            TargetCell.SetParent(CurrentCell.ContentStorage.GetChild(0), CurrentCellObj);
                            WinContoroller.SendMessage("Win");
                            OffBackLightNeighbour();
                            SetParamsToNull();
                        }

                    }
                    else
                    {
                        OffBackLightNeighbour();
                        (CurrentCellObj, CurrentCell) = SelectCell(hitObj);
                        if (SelectNeighbours.Count == 0)
                            SetParamsToNull();
                    }
                }
            }
        }
    }

    private (GameObject?, Cell?) SelectCell(GameObject selCell)
    {
        GameObject? tmpGO = null;
        Cell? tmpCell = null;
        if (selCell.tag == "Fill")
        {
            tmpGO = selCell;
            tmpCell = tmpGO.GetComponent<Cell>();
            foreach (var cellN in tmpCell.neighbours)
            {
                if (cellN.tag == "Empty")
                {
                    cellN.EnableBackLightPanel();
                    SelectNeighbours.Add(cellN);
                }
            }
        }
        return (tmpGO, tmpCell);
    }
    private (GameObject?, Cell?) SelectNeighbourCell(GameObject selCell)
    {
        GameObject? tmpGO = null;
        Cell? tmpCell = null;
        if (selCell.tag == "Empty")
        {
            tmpGO = selCell;
            tmpCell = tmpGO.GetComponent<Cell>();
        }
        return (tmpGO, tmpCell);
    }
    private void OffBackLightNeighbour()
    {
        for (int i = SelectNeighbours.Count - 1; i >= 0; i--)
        {
            SelectNeighbours[i].DisableBackLightPanel();
            SelectNeighbours.RemoveAt(i);
        }
    }
    private void SetParamsToNull()
    {
        CurrentCell = null;
        TargetCell = null;
        CurrentCellObj = null;
        TargetCell = null;
    }
}
