using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject dialogueSuccess;
    public GameObject dialogueFail;

    void Start()
    {
        dialogue1.SetActive(true);
        dialogue2.SetActive(false);
        dialogueSuccess.SetActive(false);
        dialogueFail.SetActive(false);
    }

    public void dialogueChangePositive()
    {
        dialogue1.SetActive(false);
        dialogue2.SetActive(true);
    }

    public void dialogueChangeNegative()
    {
        dialogueFail.SetActive(true);
        dialogue1.SetActive(false);
        dialogue2.SetActive(false);
    }

    public void dialogueChangeSuccess()
    {
        dialogue2.SetActive(false);
        dialogueSuccess.SetActive(true);
    }

    public void SceneChangeMainSuccessMenu()
    {
        SceneManager.LoadScene("SuccessMenu");
    }

    public void SceneChangeFailMenu()
    {
        SceneManager.LoadScene("FailMenu_debateLost");
    }
}
