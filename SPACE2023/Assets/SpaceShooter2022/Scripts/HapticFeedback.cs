using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    [SerializeField] XRBaseInteractable grabInteractable;



    private void OnEnable()
    {
        grabInteractable.activated.AddListener(SendHapticFeedback);
    }

    private void OnDisable()
    {
        grabInteractable.activated.RemoveListener(SendHapticFeedback);
    }

    private void SendHapticFeedback(ActivateEventArgs args0)
    {
        args0.interactorObject.transform.GetComponent<XRBaseController>().SendHapticImpulse(1f, 0.2f);
    }
}
