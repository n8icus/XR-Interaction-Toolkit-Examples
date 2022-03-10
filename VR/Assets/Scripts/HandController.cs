using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] InputActionReference gripAction;
    [SerializeField] InputActionReference triggerAction;

    private Animator _handAnimator;

    private void OnEnable()
    {
        gripAction.action.performed += GripAnimation;
        triggerAction.action.performed += PinchAnimation;

        gripAction.action.canceled += GripReset;
        triggerAction.action.canceled += TriggerReset;

        if(_handAnimator == null)
            _handAnimator = GetComponent<Animator>();
    }
    
    private void OnDisable()
    {
        ResetHand();

        //gripAction.action.performed -= GripAnimation;
        //triggerAction.action.performed -= PinchAnimation;

        //gripAction.action.canceled -= GripReset;
        //triggerAction.action.canceled -= TriggerReset;
    }

    private void ResetHand()
    {
        _handAnimator.SetFloat("Trigger", 0.0f);
        _handAnimator.SetFloat("Grip", 0.0f);
    }

    private void TriggerReset(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Trigger", 0.0f);
    }

    private void GripReset(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Grip", 0.0f);
    }

    private void PinchAnimation(InputAction.CallbackContext obj) => _handAnimator.SetFloat("Trigger", obj.ReadValue<float>());

    private void GripAnimation(InputAction.CallbackContext obj) => _handAnimator.SetFloat("Grip", obj.ReadValue<float>());

}
