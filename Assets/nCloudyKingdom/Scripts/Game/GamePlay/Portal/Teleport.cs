using System;
using System.Collections;
using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Portal
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private Teleport _target;
        [SerializeField] private Portal _portal;

        private PlayerBody _object;

        public Transform SpawnPoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerBody body))
            {
                if (_portal.CanTeleport)
                {
                    _object = body;
                    StartCoroutine(Transition());
                    _portal.CanTeleport = false;
                    body.SpawnEffect();
                }
            }
        }
        private IEnumerator Transition()
        {
            yield return new WaitForSeconds(1.5f);
            _object.Teleport();
            _object.transform.position = _target.SpawnPoint.position;
            _target.Recieve(_object);
        }

        public void Recieve(PlayerBody body)
        {
            StartCoroutine(SetIdle(body));
            _portal.CanTeleport = false;
        }
        private IEnumerator SetIdle(PlayerBody body)
        {
            body.SpawnEffect();
            yield return new WaitForSeconds(1); 
            body.GoIdle();
        }
    }
}