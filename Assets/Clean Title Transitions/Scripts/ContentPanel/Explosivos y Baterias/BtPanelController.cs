using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtPanelController : MonoBehaviour
{
    [Header("RIGHT TEXTS")]
    public List<GameObject> textPanels = new List<GameObject>();

    [Header("RIGHT TEXTS")]
    public List<GameObject> topRightTextPanels = new List<GameObject>();

    [Header("LEFT BUTTONS")]
    public List<GameObject> buttons = new List<GameObject>();

    [Header("IMAGES")]
    public List<GameObject> images = new List<GameObject>();

    private int index;
    private GameObject currentButton;
    private GameObject currenTextpanel;
    private GameObject currentTopRightTextpanel;
    private GameObject currenImage;


    void Start()
    {
        index = 0;
        currentButton = buttons[0];
        currenTextpanel = textPanels[0];
        currentTopRightTextpanel = topRightTextPanels[0];
        currenImage = images[0];
        ShowCurrentPanel(index);
    }

    public void OnButtonClicked(int buttonIndex = 0)
    {
        //if (buttonIndex != index)
        //{
            //Hide lastPanel
            currentButton = buttons[index];
            currentButton.GetComponentInChildren<Image>().color = new Color(0f / 255.0f, 0f / 255.0f, 0f / 255.0f, 255f / 255.0f);
            currentButton.GetComponentInChildren<Text>().color = new Color(24f / 255.0f, 231f / 255.0f, 28f / 255.0f, 255f / 255.0f);
            currenTextpanel = textPanels[index];
            currenTextpanel.SetActive(false);
            currentTopRightTextpanel = topRightTextPanels[index];
            currentTopRightTextpanel.SetActive(false);
            currenImage = images[index];
            currenImage.SetActive(false);

            //Show currentPanel
            ShowCurrentPanel(buttonIndex);

            index = buttonIndex;
        //}
    }

    private void ShowCurrentPanel(int buttonIndex)
    {
        currentButton = buttons[buttonIndex];
        currentButton.GetComponentInChildren<Image>().color = new Color(24f / 255.0f, 231f / 255.0f, 28f / 255.0f, 255f / 255.0f);
        currentButton.GetComponentInChildren<Text>().color = new Color(0f / 255.0f, 0f / 255.0f, 0f / 255.0f, 255f / 255.0f);
        currenTextpanel = textPanels[buttonIndex];
        currenTextpanel.SetActive(true);

        currentTopRightTextpanel = topRightTextPanels[buttonIndex];
        currentTopRightTextpanel.SetActive(true);
        currenImage = images[buttonIndex];
        currenImage.SetActive(true);
    }
}
