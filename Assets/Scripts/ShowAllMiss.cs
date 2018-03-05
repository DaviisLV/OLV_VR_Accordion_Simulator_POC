using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowAllMiss : MonoBehaviour
{

    public GameObject MissCollider;
    Text text;
    private string mainText = "Total miss count:";
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        MissedNoteCollector GC = MissCollider.GetComponent<MissedNoteCollector>();

        text.text = mainText + GC.GetMissedCount().ToString();

    }
}
