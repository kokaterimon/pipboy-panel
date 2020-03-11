using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReferenciasControl : MonoBehaviour
{
    [Header("STYLE PARENTS")]
    public List<GameObject> numbers = new List<GameObject>();

    [Header("SETTINGS")]
    private int currentNumberIndex = 0;

    [Header("SHOW TIMEELAPSE")]
    public GameObject timeElapsePanel;
    public GameObject keyboardPanel;
    public GameObject secretTextPanel;

    //[Header("SECRET TEXT")]
    ////public GameObject secretText;
    //public GameObject numbers;
    //public GameObject display;

    [Header("ALERT TEXT")]
    public Text alertText;

    [Header("BLOQUED PANEL")]
    public GameObject bloquedPanel;
    public int MAX_TIME_TO_WAIT = 20;
    public int MAX_TIME_TO_WAIT_AFTER_SHOW_SECRETPANEL = 40;
    public Text countdown;

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

    public static string correctCode = "67341926";
    //public static string playerCode = "INGRESE LA CLAVE";
    public static string playerCode = "";
    public static string claveIncorrecta = "";
    public static string ingreseLaClave = "";
    public static string textQuedan = "";
    public static string textIntentos = "";

    private int intentos;
    private static int MAX_INTENTOS = 4;
    private int timeLeft;

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;
    //public float lowPitchRange = 0.1f;
    //public float highPitchRange = 0.6f;
    private AudioSource currentSound;

    void Start()
    {
        intentos = MAX_INTENTOS;
        timeLeft = MAX_TIME_TO_WAIT;
    }

    void Update()
    {
        countdown.text = ("" + timeLeft);
    }

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
            if (playerCode == ingreseLaClave || playerCode == claveIncorrecta)
            {
                ResetDisplay();
            }
            else if (playerCode != "")
            {
                playerCode = playerCode.Substring(0, playerCode.Length - 1);
            }
        }
        else if (newNumberIndex == 11) //EnterKey
        {
            if (playerCode == correctCode)
            {
                Debug.Log("Correct!");
                ShowTimeElapse();
                Invoke("ShowSecretText", 1);
                Invoke("HideSecretText", MAX_TIME_TO_WAIT_AFTER_SHOW_SECRETPANEL);
            }
            else
            {
                intentos--;
                if (intentos == 0)
                {
                    BloquearPanelReferencias();
                    //Ejecutar un hilo para que luego de 5 minutos active el panel
                    //...
                    intentos = MAX_INTENTOS;
                    alertText.text = "";
                    return;
                }
                Debug.Log("Número no encontrado");
                playerCode = claveIncorrecta;
                if (PhoneControler.espEng == false) //Mostrar en español
                {
                    alertText.text = textQuedan +" "+ intentos + " " + textIntentos;
                }
                else //Mostrar en inglés
                {
                    alertText.text = "..." + intentos + " " + textIntentos + " " + textQuedan;
                }
                
            }
        }
        else
        {
            //Poner sonido a las teclas
            float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);
            currentSound = numbers[newNumberIndex].GetComponent<AudioSource>();
            currentSound.pitch = randomPitch;
            //currentSound.clip = clips[randomIndex];
            //rrentSound.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
            currentSound.clip = clip;
            currentSound.Play();

            if (playerCode == ingreseLaClave || playerCode == claveIncorrecta)
            {
                ResetDisplay();
            }
            playerCode += newNumberIndex;
            Debug.Log(playerCode);
        }
    }

    private void BloquearPanelReferencias()
    {
        keyboardPanel.SetActive(false);
        bloquedPanel.SetActive(true);
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }

    private void ActivarPanelReferencias()
    {
        keyboardPanel.SetActive(true);
        bloquedPanel.SetActive(false);
        playerCode = ingreseLaClave;
    }

    IEnumerator LoseTime()
    {
        while (timeLeft >= 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            if (timeLeft <= 0)
            {
                ActivarPanelReferencias();
            }
        }
        timeLeft = MAX_TIME_TO_WAIT;
    }

    void ResetDisplay()
    {
        playerCode = "";
    }

    void ShowTimeElapse()
    {
        keyboardPanel.SetActive(false);
        timeElapsePanel.SetActive(true);
    }

    //public void HideTimeElapse()
    //{
    //    timeElapsePanel.SetActive(false);
    //    keyboardPanel.SetActive(true);
    //}

    void ShowSecretText()
    {
        Debug.Log("Correct!");
        timeElapsePanel.SetActive(false);
        keyboardPanel.SetActive(false);
        secretTextPanel.SetActive(true);
    }

    void HideSecretText() //Restore Referencias panel after show secret text
    {
        Debug.Log("return!");
        keyboardPanel.SetActive(true);        
        secretTextPanel.SetActive(false);
        playerCode = ingreseLaClave;
    }
}
