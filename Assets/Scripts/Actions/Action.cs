using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class Action : MonoBehaviour
{
    protected bool isActing;
    public abstract void DoAction();
}





