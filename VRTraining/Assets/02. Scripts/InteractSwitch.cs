using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractSwitch : MonoBehaviour
{
    XRDirectInteractor interactor;

    private void Awake()
    {
        interactor = GetComponent<XRDirectInteractor>();
    }

    public void SwitchActionHoverOn()
    {
        interactor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.Toggle;
    }
    
    public void SwitchActionHoverExit()
    {
        interactor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.StateChange;
    }
}
