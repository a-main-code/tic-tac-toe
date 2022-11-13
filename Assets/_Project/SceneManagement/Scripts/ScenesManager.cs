using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public static class ScenesManager
    {
        public static void ReloadScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
