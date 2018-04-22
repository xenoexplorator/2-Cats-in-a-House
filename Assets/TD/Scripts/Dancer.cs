using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    [SerializeField]
    private Animator dancerAnim;

    [SerializeField]
    private string dancingStateName = "Dancing";

    [SerializeField]
    private string buildPhaseStateName = "InBuildPhase";

    public void ToggleBuildPhase(bool state)
    {
        if (dancerAnim == null)
            return;

        dancerAnim.SetBool(dancingStateName, false);
        dancerAnim.SetBool(buildPhaseStateName, state);
    }

    public void ChangeDancingState(bool state)
    {
        if (dancerAnim == null)
            return;

        dancerAnim.SetBool(dancingStateName, state);
    }
}
