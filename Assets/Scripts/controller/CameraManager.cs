using DG.Tweening;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }


    public void ZoomIn()
    {
        mainCamera.DOOrthoSize(15, 0.5f);
    }

    public void ZoomOut()
    {
        mainCamera.DOOrthoSize(10, 0.5f);
    }
}
