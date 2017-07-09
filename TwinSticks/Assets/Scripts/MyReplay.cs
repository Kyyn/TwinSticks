using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyReplay : MonoBehaviour
{

    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody myRigidbody;

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameManager.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }

    }

    private void Record()
    {
        myRigidbody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }

    void PlayBack()
    {
        myRigidbody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }
}
/// <summary>
/// A structure to store time, position and rotation.
/// </summary>
public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;


    public MyKeyFrame (float time, Vector3 pos, Quaternion rot)
    {
        frameTime = time;
        position = pos;
        rotation = rot;
    }
}