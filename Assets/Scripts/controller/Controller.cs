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

    [HideInInspector] public CameraManager cameraManager;

    [HideInInspector] public TetrisGameManager tetrisGameManager;

    [HideInInspector] public AudioManager audioManager;

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
        audioManager = GetComponent<AudioManager>();
        cameraManager = GetComponent<CameraManager>();
        tetrisGameManager = GetComponent<TetrisGameManager>();
    }


    public void Restart()
    {
        GameContext.GameOver = false;
        view.HideGameOverUI();
        Transform[,] modelMap = model.map;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                Transform shape = modelMap[i, j];
                if (shape)
                {
                    Destroy(shape.gameObject);
                    modelMap[i, j] = null;
                }
            }
        }
    }
}
