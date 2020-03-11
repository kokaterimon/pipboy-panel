using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PhoneControler : MonoBehaviour
{
    [Header("SOUNDS")]
    public List<GameObject> sounds = new List<GameObject>(); //11=atrás, 12=Enter
    //public List<AudioClip> clips = new List<AudioClip>(); //11=atrás, 12=Enter
    public AudioClip clip;

    [Header("SETTINGS")]
    public int currentNumberIndex = 0;

    [Header("SHOW/HIDE TIMEELAPSE")]
    public GameObject timeElapsePanel;
    public GameObject telephonePanel;
    public GameObject textCallingPanel;
    public GameObject textNumberNotFoundPanel;

    [Header("VIDEO REPRODUCER")]
    public GameObject videoEspanol;
    public GameObject videoIngles;
    public GameObject generalCanvas;

    [Header("LANGUAGE VIDEO BIT")]
    public static bool espEng; //esp == 0, eng == 1

    //[Header("BUTTONS ANTITECLAS")]
    //public List<GameObject> buttons = new List<GameObject>();
    //public List<GameObject> buttonsAntiteclas = new List<GameObject>();

    //Cancel video show
    private bool cancelVideoShowing = false;

    //[Header("TEXT SETTINGS")]
    //public GameObject textForChangeFontSize;

    private GameObject currentNumber;
    private GameObject nextNumber;
    private GameObject currentButton;
    private GameObject currentButtonAntitecla;

    //private int lastIndex = -1;

    private AudioSource currentSound;

    //private Text currentText;
    //private int currenttextSize = 80;

    //private Animator currentNumberAnimator;
    //private Animator nextNumberAnimator;

    public static string correctCode = "670243368";
    public static string playerCode = "";

    //public static int totalDigits = 0;

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    //public static bool mouseDown;

    //Animations
    //private string fadeInAnimation = "FadeIn";

    private void Start()
    {
        espEng = true; //por defecto video en idioma inglés
    }

    public void videoActivator(string keyPressed = "0")
    {
        cancelVideoShowing = false;

        //Reproduce sound
        //int randomIndex = UnityEngine.Random.Range(0, 2);
        float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);

        
        currentSound = sounds[Int32.Parse(keyPressed)].GetComponent<AudioSource>();
        currentSound.pitch = randomPitch;
        //currentSound.clip = clips[randomIndex];
        currentSound.clip = clip;
        currentSound.Play();

        if (keyPressed == "11") //Backspace
        {
            //if (playerCode == "Número no encontrado")
            //{
            //    ResetDisplay();
            //}else 
            if (playerCode != "")
            {
                //totalDigits -= 1;
                playerCode = playerCode.Substring(0, playerCode.Length - 1);
            }
        }
        else if (keyPressed == "10") //Enter
        {            
            if (playerCode == correctCode)
            {
                ResetDisplay();
                Debug.Log("Correct!");
                ShowTimeElapse();
                Invoke("ShowVideo", 3);
            }
            else
            {
                ResetDisplay();
                Debug.Log("Número no encontrado");
                //playerCode = "Número no encontrado";
                ShowTimeElapse();
                Invoke("HideTimeElapseNumberNotFound", 3);
            }
        }
        else
        {
            //if (playerCode == "Número no encontrado")
            //{
            //    ResetDisplay();
            //}
            if (keyPressed =="12")
            {
                keyPressed = "#";
            }
            if (keyPressed == "13")
            {
                keyPressed = "*";
            }

            playerCode += keyPressed;
            //totalDigits += 1;
        }
    }

    public void videoCancel()
    {
        cancelVideoShowing = true; //true = cancelar, false = continuar carga del video
    }

    void ResetDisplay()
    {
        playerCode = "";
        //totalDigits = 0;
    }

    void ShowTimeElapse()
    {
        timeElapsePanel.SetActive(true);
        telephonePanel.SetActive(false);
    }

    public void HideTimeElapse()
    {        
        timeElapsePanel.SetActive(false);
        telephonePanel.SetActive(true);        
    }

    private void HideTimeElapseNumberNotFound()
    {
        ShowNumberNotFoundText();
        Invoke("ResetTimeElapsePanelAndHideTimelapse", 1.2f);

    }

    private void ShowNumberNotFoundText()
    {
        textNumberNotFoundPanel.SetActive(true);
        textCallingPanel.SetActive(false);
    }

    private void ResetTimeElapsePanelAndHideTimelapse()
    {
        textNumberNotFoundPanel.SetActive(false);
        textCallingPanel.SetActive(true);
        HideTimeElapse();
    }

    void ShowVideo()
    {
        if (!cancelVideoShowing)
        {
            if (!espEng) //video en español
            {
                videoEspanol.SetActive(true);
                videoEspanol.GetComponent<VideoController>().DoAfterVideofinished();
            }
            else //video en inglés
            {
                videoIngles.SetActive(true);
                videoIngles.GetComponent<VideoController>().DoAfterVideofinished();
            }

            generalCanvas.SetActive(false);
        }
        else
            HideTimeElapse();
    }
}
