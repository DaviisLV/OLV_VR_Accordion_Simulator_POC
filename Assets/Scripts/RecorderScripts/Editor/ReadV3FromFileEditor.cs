using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;
using System.IO;
using System.Globalization;

[CustomEditor(typeof(ReadV3FromFile))]
public class ReadV3FromFileEditor : Editor
{
    private ReadV3FromFile rf;
    string[] sr;
    List<Vector3> paths = new List<Vector3>();

    private void OnEnable()
    {
        rf = (ReadV3FromFile)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Update")) Reloud();

        if (GUILayout.Button("Select File"))
        {
            SelectNewFile();
            Reloud();
        }

        if (rf.FilePath == null)
        {
            EditorGUILayout.LabelField("Select file!");
        }
        else
        {
            EditorGUILayout.LabelField("File paths: " + rf.FilePath);
        }
    }

    private void Reloud()
    {
        GetV3FromFile(rf.FilePath);
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }


    void SelectNewFile()
    {

        string path = EditorUtility.OpenFilePanel("Select controller paths file", "", "txt");
        if (path.Length != 0)
        {
            rf.FilePath = path;
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }


    void GetV3FromFile(string file)
    {

        if (File.Exists(file))
        {
            rf.V3ListOfPoints.Clear();
            sr = File.ReadAllLines(file);

            foreach (string s in sr)
            {
                string[] lineData = s.Split(',');
                float x = float.Parse(lineData[0], CultureInfo.InvariantCulture.NumberFormat);
                float y = float.Parse(lineData[1], CultureInfo.InvariantCulture.NumberFormat);
                float z = float.Parse(lineData[2], CultureInfo.InvariantCulture.NumberFormat);
                paths.Add(new Vector3(x, y, z));
            }

            rf.V3ListOfPoints = paths;
        }
        else
        {
            Debug.Log("Could not Open the file: " + file + " for reading.");
            return;
        }
    }

}
