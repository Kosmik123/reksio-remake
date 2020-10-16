using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class IntVariable : GameVariable
{
    [SerializeField]
    private int value;

    public int Get()
    {
        return value;
    }

    public void Set(int val)
    {
        value = val;
    }

}
