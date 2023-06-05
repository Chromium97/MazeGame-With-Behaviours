using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenDisplay : MonoBehaviour
{
    public string playerName;
    public float playerTotalScore;
    public float playerHighScore;
    public int gamesPlayed;

    public string outcomeCheck;
    public string outcomeDisplay;

    public string displayInfo;
    public Text displayText;

    // Start is called before the first frame update
    void Start()
    {

        outcomeCheck = PlayerPrefs.GetString("gameoutcome", "");
        if (outcomeCheck == "You Lost! Avoid the Doggies!") 
        {
            outcomeDisplay = "You Lost! Avoid the Doggies!";
        }

        if (outcomeCheck == "You Won! You caught the cat! :)")
        {
            outcomeDisplay = "You Won! You caught the cat! :)";
        }

        if (outcomeCheck == "")
        {
            outcomeDisplay = "";
        }



        //getting all player info from PlayerPrefs
        playerName = PlayerPrefs.GetString("PlayerName", "Bill");
        playerTotalScore = PlayerPrefs.GetFloat("TotalTime", 0);
        playerHighScore = PlayerPrefs.GetFloat("HighScore", 0);
        gamesPlayed = PlayerPrefs.GetInt("NumGames", 0);

        //storing in variable
        displayInfo = "" + outcomeDisplay + "\n\n" + "Welcome! " + playerName + " \n\n" + "Your Total Score is: " + playerTotalScore + " \n\n" +
            "Your Best Time is: " + playerHighScore + " \n\n" + "Number of Runs: " + gamesPlayed;

        //displaying to canvas
        displayText.text = displayInfo;

    }
}
