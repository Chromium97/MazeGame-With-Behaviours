using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameChanger : MonoBehaviour
{
    public InputField enteredName;
    public string newName;

    public void ChangeName()
    {
        //getting name from input field and setting it to the name. 
        newName = enteredName.text.ToString();
        PlayerPrefs.SetString("PlayerName",newName);
    }
}
