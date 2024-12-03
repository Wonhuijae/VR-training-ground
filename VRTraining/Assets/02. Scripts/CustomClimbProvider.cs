using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomClimbProvider : MonoBehaviour
{
    public static event Action ClimbActive;
    public static event Action ClimbInactive;

    public CharacterController controller;

    public InputActionProperty velocityLeft;
    public InputActionProperty velocityRight;

    private bool _leftActive = false;
    private bool _rightActive = false;

    void Start()
    {
        XRDirectClimbInteractor.ClimbHandActivated += HandActivated;
        XRDirectClimbInteractor.ClimbHandDeactivated += HandDeactivated;
    }
    void OnDestroy()
    {
        XRDirectClimbInteractor.ClimbHandActivated -= HandActivated;
        XRDirectClimbInteractor.ClimbHandDeactivated -= HandDeactivated;
    }

    private void HandActivated(string controllerName)
    {
        if (controllerName == "LeftHand Controller")
        {
            _leftActive = true;
            _rightActive = false;
        }
        else
        {
            _leftActive = false;
            _rightActive = true;
        }
        ClimbActive?.Invoke();
    }

    private void HandDeactivated(string controllerName)
    {
        if (_rightActive == true && controllerName == "RightHand Controller")
        {
            _rightActive = false;
            ClimbInactive?.Invoke();
        }
        else if (_leftActive == true && controllerName == "LeftHand Controller")
        {
            _leftActive = false;
            ClimbInactive?.Invoke();
        }
    }
}
    