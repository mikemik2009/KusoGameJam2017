using UnityEditor;
using System.Collections.Generic;
using System;

[CanEditMultipleObjects]
[CustomEditor(typeof(UI_ProgressBarC), true)]
public class UI_ProgressBarCEditor : Editor {
    Dictionary<string, SerializedProperty> serializedProperties = new Dictionary<string, SerializedProperty>();

    string[] properties = new string[]{
        "_max",
        "_value",
        "type",
        "barImage",

        "BarText",
        "textType",
        "showMax"
    };

    protected void OnEnable()
    {
        Array.ForEach(properties, x => {
            var p = serializedObject.FindProperty(x);
            serializedProperties.Add(x, p);
        });
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //base.OnInspectorGUI();

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(serializedProperties["_max"]);
        EditorGUILayout.PropertyField(serializedProperties["_value"]);
        EditorGUILayout.PropertyField(serializedProperties["barImage"]);
        EditorGUILayout.PropertyField(serializedProperties["type"]);

        EditorGUI.indentLevel++;
        if (serializedProperties["type"].enumValueIndex == 0)
        {
            EditorGUILayout.PropertyField(serializedProperties["BarText"]);
            EditorGUILayout.PropertyField(serializedProperties["textType"]);
            EditorGUILayout.PropertyField(serializedProperties["showMax"]);
        }
        else
        {
        }
        EditorGUI.indentLevel--;

        serializedObject.ApplyModifiedProperties();

        Array.ForEach(targets, x => ((UI_ProgressBarC)x).Refresh());
    }
}
