using UnityEngine;
using UnityEngine.UI;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root
{
    public class GamePlayUI : MonoBehaviour
    {
        public Joystick Joystick;
        public Button AttackBtn;
        public Button JumpBtn;

        public void Restart() => GameEntryPoint.Instatnce.RunGame();
    }
}