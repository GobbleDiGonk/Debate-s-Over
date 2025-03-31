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
        //calculates the minutes
        int minutes = Mathf.FloorToInt(time / 60);
        //calculates the seconds
        int seconds = Mathf.FloorToInt(time % 60);
        //arrages a format to the timer text object tied to the script
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //checks if the time is greater than zero
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        //checks if the time is below zero, stopping time at zero and ending the game
        else if(time <= 0)
        {
            time = 0;
            SceneManager.LoadScene("FailMenu_timesup");
        }
    }
}
