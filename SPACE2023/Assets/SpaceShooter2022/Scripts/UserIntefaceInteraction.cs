using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserIntefaceInteraction : MonoBehaviour, IRaycastInterface
{
    public UnityEvent OnRaycastHit;
    public void HitByRaycast()
    { 
        OnRaycastHit.Invoke();
    }

    
}
