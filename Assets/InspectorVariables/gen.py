import sys

caps = lambda s: s[0].upper()+s[1:]
Event = lambda t: f"""\
namespace InspectorVariables
{{
    [System.Serializable]
    public class {caps(t)}Event : UnityEngine.Events.UnityEvent<{t}> {{}}
}}""" 
ScriptableVariable = lambda t: f"""\
using UnityEngine;
namespace InspectorVariables
{{
    [CreateAssetMenu(menuName ="InspectorVariables/{caps(t)}")]
    public class Scriptable{caps(t)}Variable : ScriptableVariable<{t}>
    {{
        [SerializeField]
        {t} value;
        protected override {t} local_value {{ get => value; set => this.value = value; }}
    }}
}}"""

VariableEvent = lambda t:f"""\
using UnityEngine;
using UnityEngine.Events;
namespace InspectorVariables
{{
    public class {caps(t)}VariableEvent : VariableEvent<{t}>
    {{
        [SerializeField]
        Scriptable{caps(t)}Variable _value;
        [SerializeField]
        {caps(t)}Event _onChange;

        protected override ScriptableVariable<{t}> value {{ get => _value; }}
        public override UnityEvent<{t}> onChange {{ get => _onChange; }}
    }}
}}
"""
fileTypes={"./UnityEvents/":Event,"./ScriptableVariables/":ScriptableVariable,"./VariableEvents/":VariableEvent}
args = sys.argv[1:]
for t in args:
    for fp,ft in fileTypes.items():
        file_body = ft(t)
        file_name = file_body.split("public class ")[1].split(" :")[0]
        with open(fp+file_name+".cs",'w') as f:
            f.write(file_body)