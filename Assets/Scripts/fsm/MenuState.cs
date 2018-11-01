public class MenuState : FSMState
    {
        private void Awake()
        {
            stateID = StateID.Menu;
        }

        public override void DoBeforeEntering()
        {
            ctrl.view.ShowMenu();
        }
    }
