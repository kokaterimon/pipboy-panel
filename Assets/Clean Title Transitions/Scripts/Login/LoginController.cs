using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{

    [Header("STYLE PARENTS")]
    public List<GameObject> numbers = new List<GameObject>();

    [Header("SETTINGS")]
    private int currentNumberIndex = 0;

    [Header("SHOW LOGINPANEL")]
    public GameObject languageSelectionPanel;
    public GameObject topPanel;
    public GameObject bottomPanel;
    public GameObject contentPanel;
    public GameObject loginPanel;

    [Header("GENERAL CONTAINER PANEL")]
    public GameObject generalContainerPanel;

    [Header("ALERT TEXT")]
    public Text alertText;

    [Header("BUTTON ANIMS")]
    private string buttonFadeIn = "NumberButtonOpen";
    private string buttonFadeOut = "NumberButtonClose";

    [Header("SOUNDS")]
    public AudioClip clip;
    //public List<GameObject> sounds = new List<GameObject>();

    private GameObject currentNumber;
    private GameObject nextNumber;

    private Animator currentNumberAnimator;
    private Animator nextNumberAnimator;

    public static string correctCode = "227";
    public static string playerCode = "INGRESE PASSWORD";

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;
    //public float lowPitchRange = 0.1f;
    //public float highPitchRange = 0.6f;
    private AudioSource currentSound;  

    public void NumberActivator(int newNumberIndex = 0)
    {
        currentNumber = numbers[currentNumberIndex];

        currentNumberIndex = newNumberIndex;
        nextNumber = numbers[currentNumberIndex];

        currentNumberAnimator = currentNumber.GetComponent<Animator>();
        nextNumberAnimator = nextNumber.GetComponent<Animator>();

        currentNumberAnimator.Play(buttonFadeOut);
        nextNumberAnimator.Play(buttonFadeIn);

        if (newNumberIndex == 10) //BackspaceKey
        { 
                SetDisplay();
                ResetAlert();
        }
        else if (newNumberIndex == 11) //EnterKey
        {
            if (playerCode == correctCode)
            {
                Debug.Log("Correct!");
                SetDisplay();
                ShowLanguageSelection();
                //Accediendo al método de la clase GeneralController
                GameObject levelComplete = generalContainerPanel;
                GeneralController generalController = GetComponent<GeneralController>();
                generalController.Invoke("OnSuccessfulAccess", 0);
            }
            else
            {

                Debug.Log("Incorrecto!");
                //playerCode = "CLAVE INCORRECTA";
                playerCode = "";
                alertText.text = "...Incorrecto";
                SetDisplay();
            }
        }
        else
        {
            //Poner sonido a las teclas
            float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);
            //currentSound = sounds[newNumberIndex].GetComponent<AudioSource>();
            currentSound = numbers[newNumberIndex].GetComponent<AudioSource>();
            currentSound.pitch = randomPitch;
            //currentSound.clip = clips[randomIndex];
            //rrentSound.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
            currentSound.clip = clip;
            currentSound.Play();

            if (alertText.text == "...Incorrecto")
            {
                ResetAlert();
            }

            if (playerCode == "INGRESE PASSWORD")
            {
                ResetDisplay();
            }
            playerCode += newNumberIndex;
            Debug.Log(playerCode);
        }
    }

    void ResetDisplay()
    {
        playerCode = "";
        //playerCode = "INGRESE PASSWORD";
    }

    void SetDisplay()
    {        
        playerCode = "INGRESE PASSWORD";
    }

    void ResetAlert()
    {
        alertText.text = "";
    }

    void ShowLanguageSelection()
    {
        //gameObject.SetActive(false); //language Selection panel
        Debug.Log("Correct!");
        languageSelectionPanel.SetActive(true);
        //topPanel.SetActive(true);
        //bottomPanel.SetActive(true);
        //contentPanel.SetActive(true);
        loginPanel.SetActive(false);
    }
}
