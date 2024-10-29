using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Islands.WinterIslandPack.States
{
    public class SecondState : IslandBaseState
    {
        public SecondState(WinterIsland island) : base(island) {}
        
        public override void OnEnter()
        {
            _island.DestroyedObjects.Clear();
            _island.CurrentLevel = 1;
            _island.SetLevelAllObjects(_island.CurrentLevel);
            _island.CurrentLevel += 1;
            _island.StartCoroutine(_island.ChangeMesh(_island.CurrentLevel));
        }
        
        public override void Update()
        {
            if (_island.CurrentObjects.Count == 0)
            {
                Debug.Log("ToSecond");
                _island.ChangeToThirdState();
            }
        }
    }
}