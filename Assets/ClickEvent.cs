using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ClickEvent : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnClick;
    
    private void OnMouseUpAsButton()
    {
        OnClick.Invoke();
        
    }
}
