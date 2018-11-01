using UnityEngine;

/**
*  作   者 ：胡朋
*  github : https://github.com/xiaomoinfo
*  描   述 ：控制器
*/
public class Controller : MonoBehaviour
{
    [HideInInspector] public Model model;

    [HideInInspector] public View view;


    private void Start()
    {
        model = GameObject.FindWithTag("Model").GetComponent<Model>();
        view = GameObject.FindWithTag("View").GetComponent<View>();
    }
}