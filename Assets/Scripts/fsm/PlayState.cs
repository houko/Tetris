public class PlayState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseButtonClicked, StateID.Menu);
    }

    public override void DoBeforeEntering()
    {
        ctrl.view.ShowGameUI();
        ctrl.cameraManager.ZoomOut();
        ctrl.GameManager.StartGame();
    }

    public override void DoBeforeLeaving()
    {
        ctrl.view.HideGameUI();
        ctrl.view.ShowRestartButton();
    }

    public void OnPauseClicked()
    {
        fsm.PerformTransition(Transition.PauseButtonClicked);
    }
}
