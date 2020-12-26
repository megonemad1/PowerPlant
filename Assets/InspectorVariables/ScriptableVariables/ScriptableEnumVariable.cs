using UnityEngine;
namespace InspectorVariables
{
    [CreateAssetMenu(menuName = "InspectorVariables/Enum")]
    public class ScriptableEnumVariable : ScriptableVariable<string>
    {

        override public string Value
        {
            get => Name;
            set
            {  }
        }
    }
}