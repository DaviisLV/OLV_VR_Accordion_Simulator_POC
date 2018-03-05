using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSelfDestroy : MonoBehaviour {
    int caunt;
    public GameObject collisionNote;
    public StartGame sGame;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == collisionNote.tag)
        {
            sGame.Vibration();

            Destroy(other.gameObject.GetComponent<BoxCollider>());
            if (caunt < 1)
            {
                if (!music.isPlaying)
                music.Play();
            
            }       

            Destroy(other.gameObject, 1f);

            caunt++;
        }
    }

  public int GetHitCount()
    {
        return caunt;
    }
}
