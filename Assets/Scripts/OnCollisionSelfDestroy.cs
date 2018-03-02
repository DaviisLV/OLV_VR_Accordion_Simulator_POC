using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSelfDestroy : MonoBehaviour {
    int caunt;
    ParticleSystem particle;
    public AudioSource music;
    public GameObject collisionNote;
    public StartGame sGame;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == collisionNote.tag)
        {
            sGame.Vibration();
            particle = other.gameObject.GetComponentInChildren<ParticleSystem>();
            particle.Play();

            Destroy(other.gameObject.GetComponent<BoxCollider>());
            if (caunt < 1)
            {
                if (!music.isPlaying)
                music.Play();
            
            }
         
           // HitNote();

            Destroy(other.gameObject, 1f);

            caunt++;
        }
    }

  public int GetHitCount()
    {
        return caunt;
    }

    public void MissNote()
    {
        music.pitch-=0.2f;
    }
    public void HitNote()
    {
        if (music.pitch == 1) return;
        if (music.pitch < 1)
            music.pitch += 0.005f;
        if (music.pitch > 1)
            music.pitch = 1;
    }
}
