using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoolVariable : GameVariable
{
    [SerializeField]
    private bool value;

    public bool Get()
    {
        return value;
    }

    public void Set(bool val)
    {
        value = val;
    }

    public void Switch()
    { 
        value = !value;
    }


}
