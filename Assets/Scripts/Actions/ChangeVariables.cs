public class ChangeVariables : Action
{
    [System.Serializable]
    public class VariableChange
    {
        public enum VariableChangeType
        {
            SET, ADD
        }

        public string variableName;
        public VariableChangeType action;
        public int targetValue;
    }

    public VariableChange[] variables;


    public override void DoAction()
    {
        foreach (var change in variables)
        {
            switch(change.action)
            {
                case VariableChange.VariableChangeType.SET:
                    GameController.main.SetVariable(change.variableName, change.targetValue);
                    break;

                case VariableChange.VariableChangeType.ADD:
                    GameController.main.SetVariable(
                        change.variableName, 
                        change.targetValue + GameController.main.GetVariable(change.variableName));
                    break;
            }   
        }
    }
}