public class MenuState : FSMState
    {
        private void Awake()
        {
            stateID = StateID.Menu;
            AddTransition(Transition.StartButtonClicked,StateID.Play);
        }

        public override void DoBeforeEntering()
        {
            ctrl.view.ShowMenu();
            ctrl.cameraManager.ZoomIn();
        }

        public override void DoBeforeLeaving()
        {
            ctrl.view.HideMenu();
        }

        /// <summary>
        /// 开始按钮点下的操作
        /// </summary>
        public void OnStartMenuClick()
        {
            fsm.PerformTransition(Transition.StartButtonClicked);
        }

    }
