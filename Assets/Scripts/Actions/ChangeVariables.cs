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
                    StateOfGame.main.SetVariable(change.variableName, change.targetValue);
                    break;

                case VariableChange.VariableChangeType.ADD:
                    StateOfGame.main.SetVariable(
                        change.variableName, 
                        change.targetValue + StateOfGame.main.GetVariable(change.variableName));
                    break;
            }   
        }
    }
}