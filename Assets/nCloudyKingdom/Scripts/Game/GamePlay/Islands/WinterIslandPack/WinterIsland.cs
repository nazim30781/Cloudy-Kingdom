using System;
using System.Collections;
using System.Collections.Generic;
using nCloudyKingdom.Scripts.Game.GamePlay.Islands.Objects;
using nCloudyKingdom.Scripts.Game.GamePlay.Islands.WinterIslandPack.States;
using NUnit.Framework;
using UnityEngine;
using Random = Unity.Mathematics.Random;
using Tree = nCloudyKingdom.Scripts.Game.GamePlay.Islands.Objects.Tree;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Islands
{
    public class WinterIsland : MonoBehaviour
    {
        [SerializeField] private float _changeSpeed;
        
        private StateMachine.StateMachine _stateMachine;

        private FirstState _firstState;
        private SecondState _secondState;
        private ThirdState _thirdState;
        private FourthState _fourthState;

        [SerializeField] private MeshFilter MyLand;
        [SerializeField] private MeshFilter MyWater;
        [SerializeField] private List<MeshFilter> MyTrees;
        [SerializeField] private List<MeshFilter> MyHouses;
        [SerializeField] private List<MeshFilter> MyStones;

        private List<Tree> _trees;
        private List<House> _houses;
        private List<Stone> _stones;
        private Land _land;
        private Water _water;

        private List<IChanged> _objects;

        public List<IChanged> CurrentObjects;
        public List<IChanged> DestroyedObjects;

        public float CurrentTime;

        public int CurrentLevel = 0;
        public void Start()
        {
            _stateMachine = new StateMachine.StateMachine();

            _firstState = new FirstState(this);
            _secondState = new SecondState(this);
            _thirdState = new ThirdState(this);
            _fourthState = new FourthState(this);

            CurrentObjects = new List<IChanged>();
            DestroyedObjects = new List<IChanged>();

            _objects = new List<IChanged>();
            _trees = new List<Tree>();
            _houses = new List<House>();
            _stones = new List<Stone>();
            
            foreach (var tree in MyTrees)
                _trees.Add(new Tree(tree));

            foreach (var house in MyHouses)
                _houses.Add(new House(house));

            foreach (var stone in MyStones)
            {
                _stones.Add(new Stone(stone));
            }

            _land = new Land(MyLand);
            _water = new Water(MyWater);
            
            _objects.AddRange(_trees);
            _objects.AddRange(_houses);
            _objects.AddRange(_stones);
            _objects.Add(_land);
            _objects.Add(_water);
            
            CurrentObjects.AddRange(_objects);
            
            _stateMachine.Initialize(_firstState);
        }

        private void Update()
        {
            _stateMachine.CurrentState.Update();
            if (Input.GetKeyDown(KeyCode.A))
            {
                StopAllCoroutines();
                ChangeToFourthState();
            }
        }

        public void ChangeToFirstState() => _stateMachine.ChangeState(_firstState);
        public void ChangeToSecondState() => _stateMachine.ChangeState(_secondState);
        public void ChangeToThirdState() => _stateMachine.ChangeState(_thirdState);
        public void ChangeToFourthState() => _stateMachine.ChangeState(_fourthState);

        private void UpdateCurrentObjects()
        {
            CurrentObjects.Clear();
            CurrentObjects.AddRange(_objects);
        }

        public void SetLevelAllObjects(int level)
        {
            foreach (var obj in _objects)
                obj.ChangeMesh(level);
        }

        private void DownLevelRandomObject()
        {
            if (DestroyedObjects.Count > 1)
            {
                var id = UnityEngine.Random.Range(0, DestroyedObjects.Count);
                var obj = DestroyedObjects[id];
                obj.ChangeMesh(CurrentLevel-1);
                CurrentObjects.Add(obj);
                DestroyedObjects.Remove(obj);
            }
        }

        public void DownLevelFiveObjects()
        {
            for (int i = 0; i < 5; i++)
            {
                DownLevelRandomObject();
            }
        }
        
        public IEnumerator ChangeMesh(int level)
        {
            UpdateCurrentObjects();
            yield return new WaitForSeconds(_changeSpeed);
            while (CurrentObjects.Count > 0)
            {
                var value = UnityEngine.Random.Range(0, 2);
                if (value == 1)
                {
                    var id = UnityEngine.Random.Range(0, CurrentObjects.Count);
                    var obj = CurrentObjects[id];
                    DestroyedObjects.Add(obj);
                    obj.ChangeMesh(level);
                    CurrentObjects.Remove(obj);
                    
                    yield return new WaitForSeconds(_changeSpeed);
                }
            }
        } 
    }
}