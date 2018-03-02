using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Pickable))]
public class PickableEditor : Editor
{
    private Pickable t;

    private void OnEnable()
    {
        t = (Pickable)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Configure")) Configure();
    }

    private void Configure()
    {
        Rigidbody rigidBody = t.GetComponent<Rigidbody>();
        Collider collider = t.GetComponent<Collider>();

        if (rigidBody == null) rigidBody = t.gameObject.AddComponent<Rigidbody>();
        if (collider == null) collider = t.gameObject.AddComponent<BoxCollider>();

        rigidBody.isKinematic = false;
        collider.isTrigger = false;

        EditorUtility.SetDirty(t);

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

}