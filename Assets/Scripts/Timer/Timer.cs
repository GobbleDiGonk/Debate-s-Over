using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI timer;

    // Update is called once per frame
    void Update()
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else if(time <= 0)
        {
            time = 0;
            SceneManager.LoadScene("FailMenu_timesup"):
        }
    }
}
