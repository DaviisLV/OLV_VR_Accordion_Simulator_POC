using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedNoteCollector : MonoBehaviour {
    int caunt;
    public AudioSource music;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlueNotes" || other.gameObject.tag == "RedNotes")
        {
          //  MissNote();
            Destroy(other.gameObject);
            caunt++;
        }

    }
    public void MissNote()
    {
        if (music.pitch >0)
        music.pitch -= 0.01f;
    }
    public int GetMissedCount()
    {
        return caunt;
    }
}
