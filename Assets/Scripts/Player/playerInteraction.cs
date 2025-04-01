using UnityEngine;
using UnityEngine.SceneManagement;

public class playerInteraction : MonoBehaviour
{
    public GameObject finishLine;
    public GameObject failLine;

    public void Start()
    {
        finishLine.SetActive(false);
        failLine.SetActive(true);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("objective"))
        {
            Destroy(collision.gameObject);
            openFinishLine();
        }

        if (collision.CompareTag("FinishLine"))
        {            
            SceneManager.LoadScene("DebateSection");
        }

        if (collision.CompareTag("FailLine"))
        {
            SceneManager.LoadScene("FailMenu_NoNotes");
        }

        if (collision.CompareTag("obstacle"))
        {            
            SceneManager.LoadScene("FailMenu_obstacle");
        }

        if (collision.CompareTag("Tunnel"))
        {
            SceneManager.LoadScene("FailMenu_tunnel");
        }

        if(collision.CompareTag("Grass"))
        {
            SceneManager.LoadScene("FailMenu_grass");
        }
    }

    private void openFinishLine() 
    {
        finishLine.SetActive(true);
        failLine.SetActive(false);
    }
}
