using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUtils : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
