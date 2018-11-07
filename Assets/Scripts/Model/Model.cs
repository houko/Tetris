using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*  作   者 ：胡朋
*  github : https://github.com/xiaomoinfo
*  描   述 ：模型
*/
public class Model : MonoBehaviour
{
    public Transform[,] map = new Transform[10, 18];


    public bool IsValidMapPosition(Transform t)
    {
        foreach (Transform child in t)
        {
            if (child.CompareTag("Block"))
            {
                Vector2 pos = child.position.Round();
                if (map[(int) pos.x, (int) pos.y] == null)
                {
                    
                }
            }
        }

        return false;
    }
}
