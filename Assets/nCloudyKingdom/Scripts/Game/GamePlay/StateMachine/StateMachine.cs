namespace nCloudyKingdom.Scripts.Game.GamePlay.StateMachine
{
    public class StateMachine
    {
        public IState CurrentState;

        public void Initialize(IState startingState)
        {
            CurrentState = startingState;
            CurrentState.OnEnter();
        }

        public void ChangeState(IState newState)
        {
            CurrentState.OnExit();
            CurrentState = newState;
            CurrentState.OnEnter();
        }
    }
}