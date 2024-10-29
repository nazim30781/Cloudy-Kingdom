using System.Collections.Generic;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemyCounter
    {
        public List<Enemy> Enemies;

        public EnemyCounter() => Enemies = new List<Enemy>();

        public void RemoveFromList(Enemy enemy, int price) => Enemies.Remove(enemy);
    }
}