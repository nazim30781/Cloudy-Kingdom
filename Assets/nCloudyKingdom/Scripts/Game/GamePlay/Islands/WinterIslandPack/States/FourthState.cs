namespace nCloudyKingdom.Scripts.Game.GamePlay.Islands.WinterIslandPack.States
{
    public class FourthState : IslandBaseState
    {
        public FourthState(WinterIsland island) : base(island) {}
        
        public override void OnEnter()
        {
            _island.DestroyedObjects.Clear();
            _island.CurrentLevel = 3;
            _island.SetLevelAllObjects(_island.CurrentLevel);
            _island.CurrentLevel += 1;
        }
    }
}