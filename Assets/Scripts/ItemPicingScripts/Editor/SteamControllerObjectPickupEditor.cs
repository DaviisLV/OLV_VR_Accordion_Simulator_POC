using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(SteamControllerObjectPickup))]
public class SteamControllerObjectPickupEditor : Editor
{
    private SteamControllerObjectPickup t;

    private void OnEnable()
    {
        t = (SteamControllerObjectPickup)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Configure")) Configure();
    }

    private void Configure()
    {
        Rigidbody rigidbody = t.GetComponent<Rigidbody>();
        SphereCollider sphereCollider = t.GetComponent<SphereCollider>();
        FixedJoint fixedJoint = t.GetComponent<FixedJoint>();

        if (rigidbody == null) rigidbody = t.gameObject.AddComponent<Rigidbody>();
        if (sphereCollider == null) sphereCollider = t.gameObject.AddComponent<SphereCollider>();
        if (fixedJoint == null) fixedJoint = t.gameObject.AddComponent<FixedJoint>();

        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.1f;

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

}