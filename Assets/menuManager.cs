using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject titleMenu;
    public GameObject controlsMenu;

    private void Start()
    {
        titleMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }
    public void goToMainlevel()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void goBack()
    {
        controlsMenu.SetActive(false);
        titleMenu.SetActive(true);
    }

    public void goToControls()
    {
        controlsMenu.SetActive(true);
        titleMenu.SetActive(false);
    }
}
