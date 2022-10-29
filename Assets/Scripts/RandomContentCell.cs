using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomContentCell : MonoBehaviour
{
    [SerializeField] private List<GameObject> AllContent;
    [SerializeField] private List<GameObject> AllCell;
    private List<int> check = new List<int>();
    void Awake()
    {
        int i = 14;
        while (AllContent.Count != 0)
        {
            int j = Random.Range(0, AllCell.Count - 1);
            while (check.Contains(j))
            {
                j = Random.Range(0, AllCell.Count - 1);
            }
            var q = Instantiate(AllContent[i], AllCell[j].transform);
            check.Add(j);
            AllContent.RemoveAt(i);
            i--;
        }
    }

}
