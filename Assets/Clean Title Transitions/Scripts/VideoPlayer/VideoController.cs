using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [Header("VIDEO REPRODUCER")]
    public GameObject phone;
    public GameObject generalCanvas;

    VideoPlayer myVideoPlayer;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoAfterVideofinished()
    {
        myVideoPlayer = GetComponent<VideoPlayer>();
        Invoke("videoFinished", (float)myVideoPlayer.clip.length);
        phone.GetComponent<PhoneControler>().HideTimeElapse();        
        //Invoke("videoFinished", 10f);
    }

    void videoFinished()
    {
        generalCanvas.SetActive(true);
        gameObject.SetActive(false);
        myVideoPlayer.Stop();

    }
}
