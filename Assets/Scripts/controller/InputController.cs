using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Controller controller;

    private TetrisGameManager gameManager;

    private Transform pivot;

    private void Awake()
    {
        controller = GetComponent<Controller>();
        gameManager = GetComponent<TetrisGameManager>();
    }

    void Update()
    {
        Shape shape = gameManager.currentShape;
        if (shape == null)
        {
            return;
        }

        Transform shapeTransform = shape.transform;
        pivot = shapeTransform.Find("Pivot");

        // 变形
        if (Input.GetKeyDown(KeyCode.W))
        {
            shapeTransform.RotateAround(pivot.transform.position, Vector3.forward, -90);
            if (!controller.model.IsValidMapPosition(shapeTransform))
            {
                shapeTransform.RotateAround(pivot.transform.position, Vector3.forward, 90);
            }
        }
        // 下落
        else if (Input.GetKeyDown(KeyCode.S))
        {
            shape.timeInterval = shape.timeInterval / 10;
        }

        // 左移
        else if (Input.GetKeyDown(KeyCode.A))
        {
            shapeTransform.position = shapeTransform.position + new Vector3(-1, 0, 0);

            if (!controller.model.IsValidMapPosition(shapeTransform))
            {
                shapeTransform.position = shapeTransform.position + new Vector3(1, 0, 0);
            }
        }
        // 左移
        else if (Input.GetKeyDown(KeyCode.D))
        {
            shapeTransform.position = shapeTransform.position + new Vector3(1, 0, 0);
            if (!controller.model.IsValidMapPosition(shapeTransform))
            {
                shapeTransform.position = shapeTransform.position + new Vector3(-1, 0, 0);
            }
        }
    }
}
