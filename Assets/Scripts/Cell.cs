using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public List<Cell> neighbours;
    private GameObject BackLightPanel;
    public Transform ContentStorage;
    [SerializeField] private GameObject RedCell;
    [SerializeField] private GameObject BlueCell;
    [SerializeField] private GameObject GreenCell;
    private void Start()
    {
        var trn = GetComponent<Transform>();

        BackLightPanel = transform.GetChild(0).gameObject;
        var parent = trn.parent;
        ContentStorage = transform.GetChild(1);
        if (ContentStorage.childCount > 0)
        {
            this.tag = "Fill";
        }
        if (int.TryParse(this.name.Substring(4), out int thisIndex))
        {
            if (thisIndex % 5 == 0)
            {
                if (thisIndex + 1 < parent.childCount)
                    neighbours.Add(parent.GetChild(thisIndex + 1).GetComponent<Cell>());
            }
            else if ((thisIndex + 1) % 5 == 0)
            {
                if (thisIndex - 1 >= 0)
                    neighbours.Add(parent.GetChild(thisIndex - 1).GetComponent<Cell>());

            }
            else
            {
                if (thisIndex - 1 >= 0)
                    neighbours.Add(parent.GetChild(thisIndex - 1).GetComponent<Cell>());
                if (thisIndex + 1 < parent.childCount)
                    neighbours.Add(parent.GetChild(thisIndex + 1).GetComponent<Cell>());
            }
            if (thisIndex + 5 < parent.childCount)
                neighbours.Add(parent.GetChild(thisIndex + 5).GetComponent<Cell>());
            if (thisIndex - 5 >= 0)
                neighbours.Add(parent.GetChild(thisIndex - 5).GetComponent<Cell>());
        }
    }
    public void EnableBackLightPanel()
    {
        BackLightPanel.SetActive(true);
    }
    public void DisableBackLightPanel()
    {
        BackLightPanel.SetActive(false);
    }
    public void SetParent(Transform Content, GameObject LastCell)
    {
        Content.SetParent(ContentStorage);
        this.tag = "Fill";
        LastCell.tag = "Empty";
    }
}
