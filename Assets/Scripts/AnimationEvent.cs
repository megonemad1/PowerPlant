using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InspectorVariables;
using System.Linq;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField]
    event_handler[] event_Handlers;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void runEvent(ScriptableEnumVariable s)
    {
        foreach (var h in event_Handlers.Where(h => h.type == s))
            h.onAnimation.Invoke();
    }

    public void setBool(ScriptableVariable<bool> variable)
    {
        if (!animator)
            animator = GetComponent<Animator>();
        animator.SetBool(variable.Name, variable.Value);
    }
    public void setFloat(ScriptableVariable<float> variable)
    {
        if (!animator)
            animator = GetComponent<Animator>();
        animator.SetFloat(variable.Name, variable.Value);
    }
    public void setInt(ScriptableVariable<int> variable)
    {
        if (!animator)
            animator = GetComponent<Animator>();
        animator.SetInteger(variable.Name, variable.Value);
    }

}
[System.Serializable]
public class event_handler
{
    [SerializeField]
    public ScriptableEnumVariable type;
    [SerializeField]
    public UnityEvent onAnimation;

}