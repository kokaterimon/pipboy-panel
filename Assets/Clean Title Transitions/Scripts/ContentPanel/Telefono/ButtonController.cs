using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [Header("Antitecla")]
    [SerializeField]
    private GameObject antitecla;

    //private static bool mouseDown;
    private bool mouseDown;

    void Update()
    {
        if (mouseDown)
        {
            antitecla.SetActive(true);
            gameObject.GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 0.0f / 255.0f);
        }
        else
        {
            antitecla.SetActive(false);
            gameObject.GetComponent<Image>().color = new Color(24f / 255.0f, 231f / 255.0f, 28f / 255.0f, 255.0f / 255.0f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        mouseDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        mouseDown = false;
    }
}
