using UnityEngine;

namespace SceneManagement
{
    public class ReloadSceneBehaviour : MonoBehaviour
    {
        [SerializeField] private KeyCode _keyCode = KeyCode.Space;

        private void Update()
        {
            if (Input.GetKeyDown(_keyCode))
            {
                ScenesManager.ReloadScene();
            }
        }
    }
}
