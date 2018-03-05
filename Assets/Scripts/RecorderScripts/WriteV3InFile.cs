using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class WriteV3InFile : MonoBehaviour {

    [HideInInspector]
    public string FolderPath;
    public AudioSource Audio;
    public Transform RightController;
    public Transform LeftController;
    string paths;
    string _rightControlerFile;
    string _leftControllerFile;
    private bool _isRecording = false;
    private bool _isStarted = false;
    [Range(0.001f, 2f)]
    public float speed;
    StreamWriter _rightSW;
    StreamWriter _leftSW;
    float _rightContStartPos;
    float _leftContStartPos;
    public bool OverrideFile;

    public void Awake()
    {
        _rightControlerFile = Audio.name + "_" + RightController.name + ".txt";
        _leftControllerFile = Audio.name + "_" + LeftController.name + ".txt";
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartRecord();
    }

    public void StopRecord()
    {
        if (!_isStarted) return;
        _rightSW.Close();
        _leftSW.Close();
        _isRecording = false;
        _isStarted = false;
        Audio.Stop();
        Debug.Log("Stop");
    }

    public void StartRecord()
    {
        if (_isStarted) return;
        _isRecording = true;

        if (File.Exists(FolderPath + "/" + _rightControlerFile) || File.Exists(FolderPath + "/" + _leftControllerFile))
            if (!OverrideFile)
            {
                Debug.Log("File alreday exist");
                return;
            }
            else
                Debug.Log("File will be overwritten");

        FileStream _rightCFile = File.Open(FolderPath+"/"+_rightControlerFile, FileMode.Create);
        FileStream _leftCFile = File.Open(FolderPath + "/" + _leftControllerFile, FileMode.Create);

        _rightSW = new StreamWriter(_rightCFile);
        _leftSW = new StreamWriter(_leftCFile);

        _rightContStartPos = RightController.position.x;
        _leftContStartPos = LeftController.position.x;
        float diff = (_leftContStartPos - _rightContStartPos) / 2;
        _rightContStartPos += diff;
        _leftContStartPos -= diff;
         

        StartCoroutine(Record(speed));
        Audio.Play();
        _isStarted = true;
        Debug.Log("Start");
    }

    public IEnumerator Record(float speed)
    {

        while (_isRecording)
        {
            _rightSW.WriteLine(GetV3PositionRight());
            _leftSW.WriteLine(GetV3PositionLeft());
            yield return new WaitForSeconds(speed);
        }
  
    }
    string GetV3PositionRight()
    {
        return String.Format("{0:F4},{1:F4},{2:F4}", RightController.position.x - _rightContStartPos, 0, RightController.position.z);
    }
    string GetV3PositionLeft()
    {
        return String.Format("{0:F4},{1:F4},{2:F4}", LeftController.position.x - _leftContStartPos, 0, LeftController.position.z);
    }

    void OnApplicationQuit()
    {
        StopRecord();
    }
}
