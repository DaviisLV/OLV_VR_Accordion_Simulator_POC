using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearBehaviour : MonoBehaviour {
    private enum BearStatus
    {
        Danceing,
        Standing,
        Attacking
    }

    private BearStatus bStatus = BearStatus.Danceing;
    Animator anim;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bStatus = BearStatus.Standing;
            chengeBearStatus();
        } 
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            bStatus = BearStatus.Attacking;
            chengeBearStatus();
        }
           
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            bStatus = BearStatus.Danceing;
            chengeBearStatus();
        }
            

    }

    public void BearDance()
    {
        anim.Play("Dance");
    }
    public void BearStand()
    {
        anim.Play("Stand");
    }
    public void BearAttack()
    {
        anim.Play("Attack");
    }

    public void chengeBearStatus()
    {
        switch (bStatus)
        {
            case BearStatus.Danceing:
                BearDance();
                break;
            case BearStatus.Standing:
                BearStand();
                break;
            case BearStatus.Attacking:
                BearAttack();
                break;

        }
    }
}
