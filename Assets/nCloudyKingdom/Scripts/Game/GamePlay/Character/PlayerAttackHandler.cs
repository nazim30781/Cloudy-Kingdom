using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;
using UnityEngine.Serialization;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerAttackHandler : MonoBehaviour
    {
        [SerializeField] private PlayerMovementHandler _movementHandler;
        [FormerlySerializedAs("_player")] [SerializeField] private PlayerConf playerConf;
        [SerializeField] private Transform _rayPoint;
        
        public bool FollowTarget;

        private void Update()
        {
            if (FollowTarget)
            {
                RaycastHit hit;
                Ray ray = new Ray(_rayPoint.position, transform.forward);
                if (Physics.Raycast(ray, out hit, 5))
                {
                    if (hit.collider.TryGetComponent(out IAttackable enemy))
                    {
                        FollowTarget = false;
                        _movementHandler.StopMovement();
                        playerConf.ChangeToAttackState();
                    }
                }
            }
        }
    }
}