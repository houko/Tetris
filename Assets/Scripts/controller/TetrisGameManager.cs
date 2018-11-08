using UnityEngine;


public class TetrisGameManager : MonoBehaviour
{
    public Shape[] shapes;

    public Color[] colors;

    [HideInInspector] public Shape currentShape;

    private Controller controller;

    private void Awake()
    {
        controller = GetComponent<Controller>();
    }


    /// <summary>
    /// 生成shape
    /// </summary>
    private void SpawnShape()
    {
        int shapeIndex = Random.Range(0, shapes.Length);
        int colorIndex = Random.Range(0, colors.Length);
        Shape shape = Instantiate(shapes[shapeIndex], new Vector3(3, 16, 0), Quaternion.identity);
        shape.controller = controller;
        shape.gameManager = this;
        shape.Init(colors[colorIndex]);
        currentShape = shape;
    }


    public void StartGame()
    {
        GameContext.isPause = false;
    }


    public void PauseGame()
    {
        GameContext.isPause = true;
    }


    /// <summary>
    /// 落地
    /// </summary>
    public void FallDown(Transform pos)
    {
        currentShape = null;
        controller.model.PlaceShape(pos);
        CheckEnd();
    }

    private void CheckEnd()
    {
        Transform[,] modelMap = controller.model.map;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 15; j < 18; j++)
            {
                if (modelMap[i, j] != null)
                {
                    GameContext.GameOver = true;
                }
            }
        }
    }

    private void Update()
    {
        if (GameContext.GameOver)
        {
            controller.view.showGameOverUI();
            return;
        }

        if (GameContext.isPause)
        {
            return;
        }

        if (!currentShape)
        {
            SpawnShape();
        }
    }
}
