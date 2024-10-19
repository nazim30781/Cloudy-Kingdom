namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public interface IPatroller
    {
        void MoveNextTarget();
        void ChangeToPatrolState();
        void StartFollow();
        void ChangeToAttackState();
    }
}