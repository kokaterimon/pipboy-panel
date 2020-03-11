using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralController : MonoBehaviour
{
    [Header("EXPIRATION TIME")]
    public int MAX_TIME_TO_EXPIRE = 2400;     //40 minutos = 2400 sec

    [Header("PANELS TO SHOW AND HIDE")]
    public GameObject LoginPanel;
    public GameObject TopPanel;
    public GameObject BottomPanel;
    public GameObject ContentPanel;
    public GameObject LanguageSelectionPanel;
    public GameObject VideoPlayer;
    public GameObject generalCanvas;

    private Text countdown;

    void Start()
    {
    }

    void Update()
    {
    }

    public void OnSuccessfulAccess()
    {
        Invoke("ReturnToLogin", MAX_TIME_TO_EXPIRE);
    }

    void ReturnToLogin() //Return to Login
    {
        Debug.Log("return!");
        generalCanvas.SetActive(true); //VideoController --> videoFinished() --> generalCanvas.SetActive(true);
        
        TopPanel.SetActive(false);
        BottomPanel.SetActive(false);
        ContentPanel.SetActive(false);
        LanguageSelectionPanel.SetActive(false);
        VideoPlayer.SetActive(false); //VideoController --> videoFinished() -->  myVideoPlayer.Stop();

        LoginPanel.SetActive(true);

        //generalCanvas.SetActive(true);
        //gameObject.SetActive(false);

    }
}