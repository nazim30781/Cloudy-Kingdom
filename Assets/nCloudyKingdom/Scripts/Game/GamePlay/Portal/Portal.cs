using System;
using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Portal
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private GameObject _effect;
        [SerializeField] private float _teleportTime;
        
        private float _currentTime;
        
        public bool CanTeleport = true;

        private void Update()
        {
            if (!CanTeleport)
            {
                if (_currentTime <= 0)
                {
                    CanTeleport = true;
                    _currentTime = _teleportTime;
                }
                
                _currentTime -= Time.deltaTime;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerBody>() && CanTeleport)
                _effect.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PlayerBody>())
                _effect.SetActive(false);
        }
    }
}