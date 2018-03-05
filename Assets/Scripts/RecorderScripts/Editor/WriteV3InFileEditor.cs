using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;
using System.IO;
using System.Globalization;

[CustomEditor(typeof(WriteV3InFile))]
public class WriteV3InFileEditor : Editor
{
    private WriteV3InFile wf;
    private void OnEnable()
    {
        wf = (WriteV3InFile)target;
    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Select folder to save file"))
        {
            SelectNewFile();
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        if (wf.FolderPath == null)
        {
            EditorGUILayout.LabelField("Select Folder!");
        }
        else
        {
            EditorGUILayout.LabelField("Folder paths: " + wf.FolderPath);
        }

    }
    void SelectNewFile()
    {
        string path = EditorUtility.SaveFolderPanel("Select folder", "", "");
        if (path.Length != 0)
        {
            wf.FolderPath = path;
        }
    }

}
