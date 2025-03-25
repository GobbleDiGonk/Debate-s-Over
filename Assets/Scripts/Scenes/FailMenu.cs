using UnityEngine;
using UnityEngine.SceneManagement;

public class FailMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void SceneChangeMainLevel()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void SceneChangeMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
