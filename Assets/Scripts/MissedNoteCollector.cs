using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedNoteCollector : MonoBehaviour
{
    int caunt;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlueNotes" || other.gameObject.tag == "RedNotes")
        {
            Destroy(other.gameObject);
            caunt++;
        }

    }
    public int GetMissedCount()
    {
        return caunt;
    }
}
