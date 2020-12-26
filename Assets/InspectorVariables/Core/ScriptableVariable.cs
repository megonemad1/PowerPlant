using UnityEngine;
using UnityEngine.Events;

public abstract class ScriptableVariable<T> : ScriptableObject
{

    [SerializeField]
    T value;
    [HideInInspector]
    public UnityEvent<T> onChange;

    private void OnEnable()
    {
        trigger();
    }

    virtual public T Value
    {
        get => value;
        set
        {
            if (!value.Equals(this.value))
            {
                this.value = value;
                trigger();
            }
        }
    }
    [NaughtyAttributes.Button]
    public void trigger() => onChange.Invoke(value);
    private void OnValidate()
    {
        trigger();
    }
    string _name;
    public string Name
    {
        get
        {
            if (name != null)
            {
                _name = name;
            }
            return _name;
        }
        set { }
    }

}