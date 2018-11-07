/**
* author: xiaomo
* github: https://github.com/xiaomoinfo
* email: xiaomo@xiamoo.info
* QQ_NO: 83387856
* Desc: 
*/

using UnityEngine;

public static class Vector3Extension
{
    public static Vector2 Round(this Vector3 v3)
    {
        int x = Mathf.RoundToInt(v3.x);
        int y = Mathf.RoundToInt(v3.y);
        return new Vector2(x, y);
    }
}
