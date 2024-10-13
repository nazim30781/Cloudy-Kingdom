namespace nCloudyKingdom.Scripts.Game.GamePlay.StateMachine
{
    public interface IState
    {
        void OnEnter();
        void Update();
        void OnExit();
    }
}