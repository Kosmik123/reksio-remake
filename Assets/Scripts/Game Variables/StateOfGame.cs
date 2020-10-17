using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOfGame : MonoBehaviour
{
    public StateOfGame main;


    private Dictionary<string, BoolVariable> _switches;
    private Dictionary<string, IntVariable> _variables;

    // Displaying 
    [SerializeField]
    private List<BoolVariable> switches;
    [SerializeField]
    private List<IntVariable> variables;

    private void Awake()
    {
        MakeStatic();
    }

    private void MakeStatic()
    {
        if (main == null)
            main = this;
        else
            Destroy(gameObject);
    }

    public bool GetSwitch(string name)
    {
        return _switches[name].Get();
    }

    public void SetSwitch(string name, bool value)
    {
        if (!_switches.ContainsKey(name))
            CreateSwitch(name);
        _switches[name].Set(value);
    }

    private void CreateSwitch(string name)
    {
        var newSwitch = new BoolVariable(name);
        _switches.Add(name, newSwitch);
        switches.Add(newSwitch);
    }


    public int GetVariable(string name)
    {
        return _variables[name].Get();
    }

    public void SetVariable(string name, int value)
    {
        if (!_variables.ContainsKey(name))
            CreateVariable(name);
        _variables[name].Set(value);
    }
    private void CreateVariable(string name)
    {
        var newVar = new IntVariable(name);
        _variables.Add(name, newVar);
        variables.Add(newVar);
    }

}
