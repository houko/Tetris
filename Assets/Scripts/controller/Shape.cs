using UnityEngine;


public class Shape : MonoBehaviour
{
    [HideInInspector] public Controller controller;

    [HideInInspector] public GameManager gameManager;

    public float timeInterval = 5f;

    public float timeInv = 0;

    private bool pause = false;

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
            Fall();
        }
    }

    private void Fall()
    {
        if (pause)
        {
            return;
        }

        transform.position = transform.position - new Vector3(0, 1, 0);
        timeInv = 0;

        if (!controller.model.IsValidMapPosition(transform))
        {
            pause = true;
            transform.position = transform.position + new Vector3(0, 1, 0);
            gameManager.FallDown(transform);
        }

        controller.audioManager.PlayerFall();
    }
}
