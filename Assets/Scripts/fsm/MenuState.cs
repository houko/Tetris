public class MenuState : FSMState
    {
        private void Awake()
        {
            stateID = StateID.Menu;
            AddTransition(Transition.StartButtonClicked,StateID.Play);
        }

        public override void DoBeforeEntering()
        {
            ctrl.view.ShowMenuUI();
            ctrl.cameraManager.ZoomIn();
        }

        public override void DoBeforeLeaving()
        {
            ctrl.view.HideMenuUI();
        }

        /// <summary>
        /// 开始按钮点下的操作
        /// </summary>
        public void OnStartMenuClick()
        {
            fsm.PerformTransition(Transition.StartButtonClicked);
        }

    }
