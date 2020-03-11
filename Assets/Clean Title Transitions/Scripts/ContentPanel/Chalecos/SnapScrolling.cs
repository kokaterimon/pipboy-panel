using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    //[Range(1, 50)]
    [Header("Controllers")]
    //public int panCount;
    private int panCount;
    [Range(0, 500)]
    public int panOffset;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f, 5f)]
    public float scaleOffset;
    [Header("Other objects")]
    //public GameObject panPrefab;
    //public GameObject buttonPanPrefab;    
    public GameObject scrollRect;
    //Puesto que necesitamos pasarle el número de botón a ScrollButtonsWhenClicked
    //necesito crear el array de botones en la propia escena
    [Header("Buttons")]
    public GameObject[] buttons;
    [Header("Para obtener el transform de Content")]
    public GameObject transformOfContent;

    private GameObject[] instPans;
    private Vector2[] pansPos;
    private Vector2[] pansScale;

    //private string[] buttonText = {"FIRST", "SECON", "THIRD", "FOURTH", "FIVET"};

    private RectTransform contentRect;
    private Vector2 contentVector;

    private int selectedPanID;
    //private int lastSelectedPanID;
    private bool isScrolling;
    private bool buttonOrScroll; //false ==> button, true ==> scroll
    //private bool iNeedToScrollScreen; //true ==> I can scroll the screen
    
    void Start()
    {
        //BR...<
        panCount = buttons.Length;
        //BR...>

        //contentRect = GetComponent<RectTransform>();
        contentRect = transformOfContent.GetComponent<RectTransform>();
        instPans = new GameObject[panCount];
        pansPos = new Vector2[panCount];
        pansScale = new Vector2[panCount];
        for (int i = 0; i < panCount; i++)
        {
            //instPans[i] = Instantiate(buttonPanPrefab, transform, false);
            instPans[i] = buttons[i]; //BR
            //instPans[i].GetComponentInChildren<Text>().text = buttonText[i];
            instPans[i].GetComponentInChildren<Text>().color = new Color(24f/255.0f, 231f/255.0f, 28f/255.0f, 255f/255.0f); //R, G, B, a ==> el último es alpha            
            if (i == 0) continue;
            //instPans[i].transform.localPosition = new Vector2(instPans[i-1].transform.localPosition.x + buttonPanPrefab.GetComponent<RectTransform>().sizeDelta.x + panOffset,
            //    instPans[i].transform.localPosition.y);
            instPans[i].transform.localPosition = new Vector2(instPans[i - 1].transform.localPosition.x + buttons[0].GetComponent<RectTransform>().sizeDelta.x + panOffset,
                instPans[i].transform.localPosition.y); //BR
            pansPos[i] = -instPans[i].transform.localPosition;
        }
    }

    private void FixedUpdate()
    {
        if(buttonOrScroll)
        {        
        float nearestPos = float.MaxValue;
        for (int i = 0; i < panCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - pansPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanID = i;
            }
            //float scale = Mathf.Clamp(1 / (distance / panOffset) * scaleOffset, 0.5f, 1f);
            //pansScale[i].x = Mathf.SmoothStep(instPans[i].transform.localScale.x, scale, 6 * Time.fixedDeltaTime);
            //pansScale[i].y = Mathf.SmoothStep(instPans[i].transform.localScale.y, scale, 6 * Time.fixedDeltaTime);
            //instPans[i].transform.localScale = pansScale[i];

        }

        //BR...<
        putAllButtonsInBlack();

        if (selectedPanID - 1 >= 0)
        {
            //instPans[selectedPanID - 1].GetComponent<Image>().color = Color.blue;
            //if (selectedPanID - 2 >= 0) instPans[selectedPanID - 2].GetComponent<Image>().color = Color.black;
            instPans[selectedPanID - 1].GetComponentInChildren<Text>().color = new Color(24f / 255.0f, 231f / 255.0f, 28f / 255.0f, 120f / 255.0f); //R, G, B, a ==> el último es alpha            
            if (selectedPanID - 2 >= 0) instPans[selectedPanID - 2].GetComponentInChildren<Text>().color = new Color(24f / 255.0f, 231f / 255.0f, 28f / 255.0f, 30f / 255.0f);
        }

        //instPans[selectedPanID].GetComponent<Image>().color = Color.red;
        instPans[selectedPanID].GetComponentInChildren<Text>().color = new Color(24f / 255.0f, 231f / 255.0f, 28f / 255.0f, 255f / 255.0f); //R, G, B, a ==> el último es alpha            

        if (selectedPanID + 1 < panCount)
        {
            //instPans[selectedPanID + 1].GetComponent<Image>().color = Color.white;
            //if (selectedPanID + 2 < panCount) instPans[selectedPanID + 2].GetComponent<Image>().color = Color.black;
            instPans[selectedPanID + 1].GetComponentInChildren<Text>().color = new Color(24f / 255.0f, 231f / 255.0f, 28f / 255.0f, 120f / 255.0f); //R, G, B, a ==> el último es alpha            
            if (selectedPanID + 2 < panCount) instPans[selectedPanID + 2].GetComponentInChildren<Text>().color = new Color(24f / 255.0f, 231f / 255.0f, 28f / 255.0f, 30f / 255.0f);
        }

        //BR...>

        //if (lastSelectedPanID == 0)
        //{
        //    ScrollButtonsWhenClicked(selectedPanID);
        //    lastSelectedPanID = selectedPanID;
        //}
        if (isScrolling) return;
        }

        //if (iNeedToScrollScreen)
        //{
        //    SetScreenwheSelected(selectedPanID); //BR
        //    return;
        //}

        //contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, pansPos[selectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        contentVector.x = pansPos[selectedPanID].x; //BR        
        contentRect.anchoredPosition = contentVector;
        SetScreenWhenSelected(selectedPanID);
        buttonOrScroll = true; //BR
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
    }

    //Al hacer click en un botón cualquiera que no esté en el foco debe "scrollear" hasta posicionarse en el foco
    public void ScrollButtonsWhenClicked(int selectedButtonID)
    {
        //isScrolling = true;
        //contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, pansPos[selectedButtonID].x, snapSpeed * Time.fixedDeltaTime);        
        selectedPanID = selectedButtonID;
        buttonOrScroll = false;
        //contentVector.x = pansPos[selectedButtonID].x; //BR
        //contentRect.anchoredPosition = contentVector;        
    }

    public void ScrollButtonsWhenDragged(int selectedButtonID)
    {        
        selectedPanID = selectedButtonID;
    }

    //BR: desde aquí se llama a la función del sript ScrollSnapRect
    public void SetScreenWhenSelected(int selectedButtonID)
    {
        SendMessage("GoToSpecificScreen", selectedButtonID);
    }

    private void putAllButtonsInBlack()
    {
        for (int i = 0; i < panCount; i++)
        {
            instPans[i].GetComponentInChildren<Text>().color = new Color(0f, 0f, 0f, 1f); //R, G, B, a ==> el último es alpha            
        }
    }

    //public void INeedToScrollScreen(bool b)
    //{
    //    iNeedToScrollScreen = b;
    //}


}
