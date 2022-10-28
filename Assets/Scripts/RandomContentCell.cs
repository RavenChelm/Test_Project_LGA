using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomContentCell : MonoBehaviour
{
    public List<Cell> AllCells;
    private int RedCellCount = 0;
    private int BlueCellCount = 0;
    private int GreenCellCount = 0;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag != "Block")
            {
                int randomNumber = Random.Range(0, 2);
                switch (randomNumber)
                {
                    case 0:
                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    default:

                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
