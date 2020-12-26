using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InspectorVariables;
using System.Linq;
using System;

public class SimonSays : MonoBehaviour
{
    [SerializeField]
    GameObject Interactions;
    [SerializeField]
    BoolandHilight[] Switches;
    [SerializeField]
    ScriptableBoolVariable[] Levels;
    [SerializeField]
    ScriptableBoolVariable isShowingSteps;
    [SerializeField]
    int StepsPerLevel = 1;
    [SerializeField]
    float flashDuration = 1f;
    [SerializeField]
    float flashintervel = 1f;
    [SerializeField]
    UnityEngine.Events.UnityEvent onWin;
    IEnumerable<BoolandHilight> Patten = new BoolandHilight[0];
    [SerializeField]
    BoolandHilight[] CurrentPatten = new BoolandHilight[0];

    // Start is called before the first frame update
    private void Awake()
    {
        LevelUP();
    }
    public void PlayerMove(ScriptableVariable<bool> move)
    {
        if (!isShowingSteps.Value)
        {
            if (CurrentPatten.FirstOrDefault()?.value == move)
            {
                CurrentPatten = CurrentPatten.Skip(1).ToArray();
            }
            else
            {
                StartCoroutine(Demo());
            }
            if (!CurrentPatten.Any())
            {
                LevelUP();
            }
        }
    }

    public IEnumerator Demo()
    {
        isShowingSteps.Value = true;
        CurrentPatten = new BoolandHilight[0].Concat(Patten).ToArray();
        Interactions.SetActive(false);
        yield return new WaitForSeconds(flashintervel);
        foreach (var s in Patten)
        {
            s.hilight.SetActive(true);
            yield return new WaitForSeconds(flashDuration);

            s.hilight.SetActive(false);
            yield return new WaitForSeconds(flashintervel);
        }
        Interactions.SetActive(true);
        isShowingSteps.Value = false;

    }

    private void LevelUP()
    {
        if (Patten.Count() / StepsPerLevel >= Levels.Length)
        {
            onWin.Invoke();
        }
        else
        {
            Levels.ElementAtOrDefault(Patten.Count() / StepsPerLevel).Toggle();
            var new_steps = new BoolandHilight[StepsPerLevel];
            for (int i = 0; i < new_steps.Length; i++)
            {
                new_steps[i] = Switches[UnityEngine.Random.Range(0, Switches.Length)];
            }
            Patten = Patten.Concat(new_steps);
            StartCoroutine(Demo());
        }
    }
}
[Serializable]
public class BoolandHilight
{
    public ScriptableBoolVariable value;
    public GameObject hilight;
}
