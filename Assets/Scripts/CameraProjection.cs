using UnityEngine;

    public class CameraProjection : MonoBehaviour
    {
        private void Awake()
        {
            if (Screen.width / (float) Screen.height >= (768 / (float) 1024)) //当设备比较宽的时候
            {
                float size = 384 / (Screen.width / (float) Screen.height);
                transform.GetComponent<Camera>().orthographicSize = 512;
            }
            else
            {
                //当设备比较窄的时候
                float size = 384 / (Screen.width / (float) Screen.height);

                transform.GetComponent<Camera>().orthographicSize = size;
            }
        }
    }
