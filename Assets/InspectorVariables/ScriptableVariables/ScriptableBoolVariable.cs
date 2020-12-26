using UnityEngine;
namespace InspectorVariables
{
    [CreateAssetMenu(menuName ="InspectorVariables/Bool")]
    public class ScriptableBoolVariable : ScriptableVariable<bool>, IBoolLike
    {
        public void Toggle()
        {
            Value = !Value;
        }
    }
}