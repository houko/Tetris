using UnityEngine;


public class TetrisGameManager : MonoBehaviour
{
    public Shape[] shapes;

    public Color[] colors;

    private Shape currentShape;

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
    }

    private void Update()
    {
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
