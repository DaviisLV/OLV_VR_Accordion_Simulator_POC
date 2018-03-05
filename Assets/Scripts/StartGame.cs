using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public GameObject NoteLine;

    private const Valve.VR.EVRButtonId Menu = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
    private const Valve.VR.EVRButtonId Grip = Valve.VR.EVRButtonId.k_EButton_Grip;

    private SteamVR_TrackedObject _trackedObj;
    private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)_trackedObj.index); } }

    private void Start()
    {
        _trackedObj = GetComponent<SteamVR_TrackedObject>();

    }

    private void Update()
    {
        if (Controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        if (Controller.GetPressDown(Menu))
        {
           
            NoteLine.SetActive(true);

        }

        if (Controller.GetPressDown(Grip))
        {
            SceneManager.LoadScene("VRMainScene");

        }
    }

    public void Vibration()
    {
        Controller.TriggerHapticPulse(2500, Valve.VR.EVRButtonId.k_EButton_Axis0);
    }


    }
