using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MenuButtons : MonoBehaviour
    {
        private int m_mainSceneIndex = 1;

        public void LoadMainScene()
        {
            SceneManager.LoadScene(m_mainSceneIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}