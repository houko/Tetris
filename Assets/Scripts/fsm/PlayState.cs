public class PlayState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseButtonClicked, StateID.Menu);
    }

    public override void DoBeforeEntering()
    {
        ctrl.view.ShowGame();
        ctrl.cameraManager.ZoomOut();
        ctrl.tetrisGameManager.StartGame();
    }

    public override void DoBeforeLeaving()
    {
        ctrl.view.HideGame();
    }

    public void OnPauseClicked()
    {
        fsm.PerformTransition(Transition.PauseButtonClicked);
    }
}