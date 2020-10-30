using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChangeSwitches : Action
{
    [System.Serializable]
    public class SwitchChange
    {
        public enum SwitchTargetValue
        {
            ON, OFF, INVERSE
        }

        public string switchName;
        public SwitchTargetValue targetValue;
    }

    public SwitchChange[] switches;


    public override void DoAction()
    {
        foreach (var change in switches)
        {
            switch (change.targetValue)
            {
                case SwitchChange.SwitchTargetValue.ON:
                    GameController.main.SetSwitch(change.switchName, true);
                    break;

                case SwitchChange.SwitchTargetValue.OFF:
                    GameController.main.SetSwitch(change.switchName, false);
                    break;

                case SwitchChange.SwitchTargetValue.INVERSE:
                    GameController.main.SetSwitch(
                        change.switchName,
                        !GameController.main.GetSwitch(change.switchName));
                    break;
            }
        } 
    }
}

