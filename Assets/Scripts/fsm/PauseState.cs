public class PauseState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Pause;
        AddTransition(Transition.StartButtonClicked, StateID.Play);
    }

    public override void DoBeforeEntering()
    {
        GameContext.isPause = true;
    }


    public override void DoBeforeLeaving()
    {
        GameContext.isPause = false;
    }
}
