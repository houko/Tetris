using UnityEngine;


public class Shape : MonoBehaviour
{
    public float timeInterval = 0.5f;

    public float timeInv = 0;

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

    private void Update()
    {
        if (GameContext.isPause)
        {
            return;
        }

        timeInv += Time.deltaTime;
        if (timeInv >= timeInterval)
        {
            transform.position = transform.position - new Vector3(0, 1, 0);
            timeInv = 0;
        }
    }
}
