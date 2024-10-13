using UnityEngine;

namespace nCloudyKingdom.Scripts
{
    public class UIRootView : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Transform _sceneUIContainer;

        private void Awake()
        {
            HideLoadingScreen();
        }

        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }

        public void AttachUI(GameObject sceneUIPrefab)
        {
            ClearSceneUIContainer();
            Instantiate(sceneUIPrefab, _sceneUIContainer);
        }

        public void ClearSceneUIContainer()
        {
            for (int i = 0; i < _sceneUIContainer.childCount; i++)
            {
                Destroy(_sceneUIContainer.GetChild(i).gameObject);
            }
        }
    }
}