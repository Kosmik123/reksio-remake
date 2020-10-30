using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController main;

    [HideInInspector]
    public AudioSource audioSource;

    private Dictionary<string, BoolVariable> _switches = new Dictionary<string, BoolVariable>();
    private Dictionary<string, IntVariable> _variables = new Dictionary<string, IntVariable>();

    // Displaying 
    [SerializeField]
    private List<BoolVariable> switches = new List<BoolVariable>();
    [SerializeField]
    private List<IntVariable> variables = new List<IntVariable>();

    private void Awake()
    {
        MakeStatic();
    }

    private void Start()
    {

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
            Debug.LogError("Przełącznik o nazwie " + name + " NIE istnieje!");
        _switches[name].Set(value);
    }
    private void CreateSwitch(string name)
    {
        if (_switches.ContainsKey(name))
            Debug.LogError("Przełącznik o nazwie " + name + " już istnieje!");
        else
        {
            var newSwitch = new BoolVariable(name);
            _switches.Add(name, newSwitch);
            switches.Add(newSwitch);
        }
    }
    private void DeleteSwitch(string name)
    {
        if (_switches.ContainsKey(name))
        {
            var newVar = new IntVariable(name);
            _switches.Remove(name);
            switches.Remove(switches.Find(s => s.name == name));
        }
        else
            Debug.LogError("Przełącznik o nazwie " + name + " NIE istnieje!");
    }

    public int GetVariable(string name)
    {
        return _variables[name].Get();
    }

    public void SetVariable(string name, int value)
    {
        if (!_variables.ContainsKey(name))
            Debug.LogError("Zmienna o nazwie " + name + " NIE istnieje!");
        _variables[name].Set(value);
    }
    private void CreateVariable(string name)
    {
        if (_variables.ContainsKey(name))
            Debug.LogError("Zmienna o nazwie " + name + " już istnieje!");
        else
        {
            var newVar = new IntVariable(name);
            _variables.Add(name, newVar);
            variables.Add(newVar);
        }
    }
    private void DeleteVariable(string name)
    {
        if (_variables.ContainsKey(name))
        {
            var newVar = new IntVariable(name);
            _variables.Remove(name);
            variables.Remove(variables.Find(v => v.name == name));
        }
        else
            Debug.LogError("Zmienna o nazwie " + name + " NIE istnieje!");
    }

    private void UpdateLists()
    {
        switches.Clear();
        switches.AddRange(_switches.Values);

        variables.Clear();
        variables.AddRange(_variables.Values);
    }



#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        UpdateLists();
    }


    [CustomEditor(typeof(GameController))]
    public class GameControllerEditor : Editor
    {
        string varName = "";
        
        public void OnGUI()
        {

        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GUILayout.Space(20);
            
            varName = EditorGUILayout.TextField("Switch/variable name: ", varName);

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Create switch"))
            {
                GameController controller = target as GameController;
                controller.CreateSwitch(varName);
            }
            if (GUILayout.Button("Create variable"))
            {
                GameController controller = target as GameController;
                controller.CreateVariable(varName);
            }
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Delete switch"))
            {
                GameController controller = target as GameController;
                controller.DeleteSwitch(varName);
            }
            if (GUILayout.Button("Delete variable"))
            {
                GameController controller = target as GameController;
                controller.DeleteVariable(varName);
            }
            EditorGUILayout.EndHorizontal();
        }
    }


#endif
}
