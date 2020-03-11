using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTTDemoManager : MonoBehaviour {

    //[Header("STYLE OBJECTS")]
    //public List<GameObject> objects = new List<GameObject>();

    [Header("STYLE PARENTS")]
    public List<GameObject> panels = new List<GameObject>();

    //[Header("STYLE BUTTONS")]
    //public List<GameObject> buttons = new List<GameObject>();

    [Header("STYLE BUTTONS")]
    public List<GameObject> BG_Black_underline = new List<GameObject>();

    [Header("STYLE BUTTONS")]
    public List<GameObject> BG_Green_square = new List<GameObject>();

    [Header("SETTINGS")]
    public int currentPanelIndex = 0;
    //private int currentButtonlIndex = 0;
    //private int currentStylelIndex = 0;

    //// [Header("PANEL ANIMS")]
    //private string panelFadeIn = "Panel Open";
    //private string panelFadeOut = "Panel Close";
    //private string styleExpand = "Expand";

    //// [Header("BUTTON ANIMS")]
    //private string buttonFadeIn = "Button Open";
    //private string buttonFadeOut = "Button Close";

    private GameObject currentPanel;
    private GameObject nextPanel;
    //private GameObject styleObject;

    //private GameObject currentButton;
    //private GameObject nextButton;

    //private Animator currentPanelAnimator;
    //public Animator nextPanelAnimator;
    //private Animator styleAnimator;

    //private Animator currentButtonAnimator;
    //private Animator nextButtonAnimator;
    
    void Start ()
    {
        //	currentButton = buttons[currentPanelIndex];
        //      currentButtonAnimator = currentButton.GetComponent<Animator>();
        //      currentButtonAnimator.Play(buttonFadeIn);

        //      currentPanel = panels[currentPanelIndex];
        //      currentPanelAnimator = currentPanel.GetComponent<Animator>();
        //      currentPanelAnimator.Play(panelFadeIn);
        currentPanel = panels[currentPanelIndex];
        currentPanel.SetActive(false);
        //      //styleObject = objects[currentStylelIndex];
        //      //styleAnimator = currentPanel.GetComponent<Animator>();
        //      //styleAnimator.Play(styleExpand);

        //      nextPanel = panels[currentPanelIndex];
        //      nextPanelAnimator = nextPanel.GetComponent<Animator>();
        nextPanel = panels[currentPanelIndex];
        nextPanel.SetActive(true);
        GetSelectedUnderline();
    }

    public void PanelAnim(int newPanel)
    {
        if (newPanel != currentPanelIndex)
        {
            currentPanel = panels[currentPanelIndex];

            currentPanelIndex = newPanel;
            nextPanel = panels[currentPanelIndex];

            currentPanel.SetActive(false);
            nextPanel.SetActive(true);

            //currentPanelAnimator = currentPanel.GetComponent<Animator>();
            //nextPanelAnimator = nextPanel.GetComponent<Animator>();

            //currentPanelAnimator.Play(panelFadeOut);
            //nextPanelAnimator.Play(panelFadeIn);

            //currentButton = buttons[currentButtonlIndex];

            //currentButtonlIndex = newPanel;
            //nextButton = buttons[currentButtonlIndex];

            //currentButtonAnimator = currentButton.GetComponent<Animator>();
            //nextButtonAnimator = nextButton.GetComponent<Animator>();

            //currentButtonAnimator.Play(buttonFadeOut);
            //nextButtonAnimator.Play(buttonFadeIn);

            //currentStylelIndex = newPanel;
            //styleAnimator = currentPanel.GetComponent<Animator>();
            //styleAnimator.Play(styleExpand);

            GetSelectedUnderline(newPanel);

            //Tengo que llamar a PanelActivator desde esta clase
            //...
        }
    }

    void GetSelectedUnderline(int selectedButton = 0)
    {
        switch (selectedButton)
        {
            case 0:
                PutAllTofalse();
                BG_Black_underline[0].SetActive(true);
                BG_Green_square[0].SetActive(true);
                break;
            case 1:
                PutAllTofalse();
                BG_Black_underline[1].SetActive(true);
                BG_Green_square[1].SetActive(true);
                break;
            case 2:
                PutAllTofalse();
                BG_Black_underline[2].SetActive(true);
                BG_Green_square[2].SetActive(true);
                break;
            case 3:
                PutAllTofalse();
                BG_Black_underline[3].SetActive(true);
                BG_Green_square[3].SetActive(true);
                break;
            case 4:
                PutAllTofalse();
                BG_Black_underline[4].SetActive(true);
                BG_Green_square[4].SetActive(true);
                break;
        }
    }

    private void PutAllTofalse()
    {
        for (int i = 0; i < BG_Black_underline.Count; i++)
        {
            BG_Black_underline[i].SetActive(false);
            BG_Green_square[i].SetActive(false);
        }
    }

    public void Restart()
    {
        //nextPanelAnimator.Play("");
        //nextPanelAnimator.Play(panelFadeIn);
    }
}
