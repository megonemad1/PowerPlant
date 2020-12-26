using UnityEngine;
using UnityEngine.Events;

namespace InspectorVariables
{
    public class BoolVariableEvent : MonoBehaviour
    {
        [SerializeField]
        BoolVarField[] events = new BoolVarField[0];
        private void OnEnable()
        {
            foreach (var e in events)
            {
                e.Enable();
            }
        }
        private void OnDisable()
        {
            foreach (var e in events)
            {
                e.Disable();
            }
        }
        private void OnValidate()
        {
            foreach (var e in events)
            {
                e.Validate();
            }
        }
    }
    [System.Serializable]
    public class BoolVarField : VariableEvent<bool>, IBoolLike
    {
        public void Toggle()
        {
            value.Value = !value.Value;
        }
    }
}
