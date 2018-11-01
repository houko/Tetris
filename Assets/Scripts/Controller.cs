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

    private FSMSystem fsm;

    private void Start()
    {
        fsm = new FSMSystem();
        FSMState[] fsmStates = GetComponentsInChildren<FSMState>();
        foreach (var state in fsmStates)
        {
            fsm.AddState(state, this);
        }

        MenuState menuState = GetComponentInChildren<MenuState>();
        fsm.setCurrentState(menuState);
    }


    private void Awake()
    {
        model = GameObject.FindWithTag("Model").GetComponent<Model>();
        view = GameObject.FindWithTag("View").GetComponent<View>();
    }
}