using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    //Reference an array of camera gameobjects
    public GameObject[] cameras;
    int camNumber = 0;

    private void Start()
    {
        //Call method to initialize the first camera on startup.
        /*
         * Calling this method, as there was a bug where initial Unity chan camera would not appear
         * after the cinematic intro.
        */
        StartCoroutine(delayCam());
        
    }


    // Start is called before the first frame update
    void SetCamera()
    {
        //increase camera counter, if the camNumber is greater than array, reset to 0
        camNumber++;
        if (camNumber >= cameras.Length)
        {
            camNumber = 0;
        }

        //Iterate through array, set the cameras to inactive and activate the camera at array point (camNumber)
        foreach (GameObject c in cameras)
        {
            c.SetActive(false);
            cameras[camNumber].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the user presses C call the SetCamera function.
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetCamera();
        }
    }

    IEnumerator delayCam() 
    {

        yield return new WaitForSeconds(110f);
        SetCamera();
    }
}
