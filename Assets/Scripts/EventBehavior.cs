using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EventBehaviour
{
    public SwitchCondition[] switchConditions;
    public VariableCondition[] variableConditions;
    public Action[] actions;
}


public class EventBehavior : MonoBehaviour
{


    public Condition conditions;



    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class Condition
{

}

[System.Serializable]
public class SwitchCondition : Condition
{
    public string switchNamed;
    public bool _is;
}

[System.Serializable]
public class VariableCondition : Condition
{

    public enum VariableRelation
    {
        LESS,
        NOT_GREATER,
        EQUAL,
        NOT_LESS,
        GRATER,
        NOT_EQUAL
    }

    public string variableNamed;
    public VariableRelation _is;
    public int number;

}

