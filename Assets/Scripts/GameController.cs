using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject RightArm;
    public GameObject LeftArm;
    public BearBehaviour bear;
    public int[,] array = new int[4, 3] { { 4,-4, 4 }, { 4,-2, 2 }, { 3,-1, 3 }, { 10,-4, 4 } };
    public int timeindex = 0;
    bool corrutineRuning = false;
    public GameObject HeadCamera;
    public GameObject boxPrefab;
    private GameObject box;
    // Use this for initialization
    void Start () {

          
  for (int i = 0; i <5; i++)
        {
        Debug.Log("test");
            box = Instantiate(boxPrefab);
            box.transform.position = new Vector3(HeadCamera.transform.position.x + (0.5f*i), HeadCamera.transform.position.y - 0.4f, HeadCamera.transform.position.z + 0.5f);


        }
    }

    // Update is called once per frame
    void Update()
    {
        GoTrueArray();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
  
           
        }
        //left arm
        if (Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene("Main");
            //MoveArmLeft(LeftArm, 10,-4);
        }
        if (Input.GetKey(KeyCode.X))
        {
            MoveArmRight(LeftArm,10,-1);
        }
        //right arm
        if (Input.GetKey(KeyCode.N))
        {
            MoveArmLeft(RightArm, 10, 1);
        }
        if (Input.GetKey(KeyCode.M))
        {
            MoveArmRight(RightArm,10,4);
        }
    }

    void GoTrueArray()
    {
        if (timeindex <= 3)
        {
            if (!corrutineRuning)
                StartCoroutine(PositionSwicher(array[timeindex, 0]));
            if (corrutineRuning)
            {
             //   Debug.Log(LeftArm.transform.position.x +">="+ (array[timeindex, 1]+0.5f) +"&&"+ LeftArm.transform.position.x +" >= "+(array[timeindex, 1]-0.5f));
                if ( LeftArm.transform.position.x - 0.5f >= array[timeindex, 1] && LeftArm.transform.position.x + 0.5f >= array[timeindex, 1])
                {
                    bear.BearStand();
                }
                else
                {
                    bear.BearAttack();
                }

            }
        }
        else
        {
            timeindex = 0;
        }


    }

    public int GetArmPosition()
    {
        return array[timeindex, 1];
    }
    IEnumerator PositionSwicher(int timeTillSwich)
    {
        corrutineRuning = true;
        yield return new WaitForSeconds(timeTillSwich);
        Debug.Log(timeindex+"/"+ timeTillSwich);
        timeindex++;
        corrutineRuning = false; 
    }

        #region arm movment
        public void MoveArmLeft(GameObject arm,int moveSpeed,int stopPosition)
    {
        if (arm.transform.position.x > stopPosition)
            arm.transform.position += Vector3.left * Time.deltaTime * moveSpeed;

    }
    public void MoveArmRight(GameObject arm, int moveSpeed, int stopPosition)
    {
        if (arm.transform.position.x < stopPosition)
            arm.transform.position += Vector3.right * Time.deltaTime * moveSpeed;

    }
    #endregion
}
