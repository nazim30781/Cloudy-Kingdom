using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class Enemy : MonoBehaviour, IAttackable
    {
        public void TakeDamage()
        {
            Debug.Log("Bolno");
        }

        public Vector3 GetDestinationPoint()
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            return hit.point;
        }
    }
}