using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{

    public static TimeController instance;

    public Text timeCounter;
    public Text timeLeft;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elaspedTime;

    public float lastScore;

    public GameObject unityChan;

    public int gamesPlayed;
    public float totalTime;

    public float timeRemaining = 120f;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {


        //increasing the number of games played
        gamesPlayed = PlayerPrefs.GetInt("NumGames", 0);
        gamesPlayed = gamesPlayed + 1;
        PlayerPrefs.SetInt("NumGames", gamesPlayed);

        //getting the latest sore and calling BeginTimer
        lastScore = PlayerPrefs.GetFloat("HighScore", 0);
        timeLeft.enabled = false;
        timeCounter.enabled = false;
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
        StartCoroutine(delayStart());
        
    }

    public void BeginTimer() 
    {
        timerGoing = true;
        elaspedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
               
        //Increaing the total time that the player has played the game
        float newTime = (float)timePlaying.TotalSeconds;

        totalTime = PlayerPrefs.GetFloat("TotalTime", 0);
        totalTime = totalTime + newTime;
        PlayerPrefs.SetFloat("TotalTime", totalTime);

        if (lastScore == 0) {
            PlayerPrefs.SetFloat("HighScore", newTime);
        }
        //setting new high score
        else if (newTime <= lastScore) 
        {
            PlayerPrefs.SetFloat("HighScore", newTime);
        }
    }

    private IEnumerator UpdateTimer()
    {
        //looping through adding time to timeplaying and displaying to the canvas
        while (timerGoing) 
        {

            timeRemaining -= Time.deltaTime;
            elaspedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elaspedTime);
            string timePlayingString = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            string timePlayerHasLeft = "Time Reaming: " + timeRemaining.ToString("0.00");
            timeLeft.text = timePlayerHasLeft;
            timeCounter.text = timePlayingString;

            yield return null;
        }
    }

    //if unityChan enters invisible square, end timer, destroy unity chan, and set home button to true.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "unityChan")
        {
            EndTimer();
            Destroy(unityChan, 2.0f);
            SceneManager.LoadScene("HomeScreen");
        }
    }

    IEnumerator delayStart() 
    {
        yield return new WaitForSeconds(56f);
        timeLeft.enabled = true;
        timeCounter.enabled = true;
        BeginTimer();

    }
}
