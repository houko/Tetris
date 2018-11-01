using UnityEngine;


public class Shape : MonoBehaviour
{
    public void Init(Color color)
    {
        foreach (Transform trans in transform)
        {
            if (trans.CompareTag("Block"))
            {
                trans.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
}