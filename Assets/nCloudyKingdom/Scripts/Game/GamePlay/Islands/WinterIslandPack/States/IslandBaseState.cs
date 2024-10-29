using nCloudyKingdom.Scripts.Game.GamePlay.StateMachine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Islands
{
    public class IslandBaseState : IState
    {
        protected WinterIsland _island;

        public IslandBaseState(WinterIsland island)
        {
            _island = island;
        }
        public virtual void OnEnter()
        {
            
        }

        public virtual void Update()
        {
            
        }

        public virtual void OnExit()
        {
            
        }
    }
}