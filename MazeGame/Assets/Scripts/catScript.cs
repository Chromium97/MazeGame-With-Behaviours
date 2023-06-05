using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class catScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "unityChan")
        {
            TimeController tc = new TimeController();
            tc.EndTimer();
            PlayerPrefs.SetString("gameoutcome", "You Won! You caught the cat! :)");
            SceneManager.LoadScene("HomeScreen");
        }
    }
}
