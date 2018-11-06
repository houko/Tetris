using UnityEngine;


public class TetrisGameManager : MonoBehaviour
{
    public Shape[] shapes;

    public Color[] colors;

    private Shape currentShape;


    /// <summary>
    /// 生成shape
    /// </summary>
    private void SpawnShape()
    {
        int shapeIndex = Random.Range(0, shapes.Length);
        int colorIndex = Random.Range(0, colors.Length);
        Shape shape = Instantiate(shapes[shapeIndex], new Vector3(4, 20, 0), Quaternion.identity);
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