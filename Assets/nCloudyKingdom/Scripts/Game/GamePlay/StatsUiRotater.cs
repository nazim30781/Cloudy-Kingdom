using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay
{
    public class StatsUiRotater : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            transform.LookAt(
                new Vector3(
                    _camera.transform.position.x, 
                    360 - transform.position.y, 
                    _camera.transform.position.z
                    )
                );
        }
    }
}