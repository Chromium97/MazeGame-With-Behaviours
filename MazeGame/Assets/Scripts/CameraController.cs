using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Cam variables
    public CinemachineVirtualCamera panningCamera;
    public CinemachineVirtualCamera zoomUnityCam;
    public CinemachineVirtualCamera zoomUnityOutCam;
    public CinemachineVirtualCamera finalGoalCam;

    //Movement speed of the cameras
    public float panCamSpeed = 0.00001f;
    public float zoomCamSpeed = 0.000001f;
    public float zoomOutCamSpeed = -0.0000001f;
    public float goalCamSpeed = 0.000001f;
    // Start is called before the first frame update
    void Start()
    {
        //setting all cameras to false as to not view them
        panningCamera.enabled = false;
        zoomUnityCam.enabled = false;
        zoomUnityOutCam.enabled = false;
        finalGoalCam.enabled = false;

        //Calling Coroutine
        StartCoroutine(camControll());
    }

    // Update is called once per frame
    void Update()
    {
        //Every frame, grabbing the CinemachineTrackedDolly component, 
        //accessing the PathPostion and adding the camera speed to it 
        //This is applied to both cameras
        var panCameraPos = panningCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        panCameraPos.m_PathPosition += panCamSpeed;
        
        var zoomUnityCamPos = zoomUnityCam.GetCinemachineComponent<CinemachineTrackedDolly>();
        zoomUnityCamPos.m_PathPosition += zoomCamSpeed;

        var zoomOutUnityCamPos = zoomUnityOutCam.GetCinemachineComponent<CinemachineTrackedDolly>();
        zoomOutUnityCamPos.m_PathPosition += zoomOutCamSpeed;

        var finalGoalCamPos = finalGoalCam.GetCinemachineComponent<CinemachineTrackedDolly>();
        finalGoalCamPos.m_PathPosition += goalCamSpeed;

    }

    IEnumerator camControll()
    {
        //Setting particular camera to true to enable the view
        // - Updating the movement speed
        // - Waiting for the camera to complete its movement
        // - Disabling the camera, repeat.
        panningCamera.enabled = true;
        panCamSpeed = 0.01f;
        yield return new WaitForSeconds(20f);
        panningCamera.enabled = false;

        zoomUnityCam.enabled = true;
        yield return new WaitForSeconds(4f);
        zoomCamSpeed = 0.005f;
        yield return new WaitForSeconds(8f);
        zoomUnityCam.enabled = false;

        zoomUnityOutCam.enabled = true;
        yield return new WaitForSeconds(4f);
        zoomOutCamSpeed = 0.005f;

        yield return new WaitForSeconds(6f);
        zoomUnityOutCam.enabled = false;

        finalGoalCam.enabled = true;
        goalCamSpeed = 0.01f;
        yield return new WaitForSeconds(10f);
        finalGoalCam.enabled = false;

    }
}
