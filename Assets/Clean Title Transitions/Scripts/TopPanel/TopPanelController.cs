using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPanelController : MonoBehaviour
{
    [Header("PANELS TO HIDE AND SHOW")]
    public GameObject languageSelectionPanel;
    public GameObject bottomPanel;
    public GameObject contentPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnConfigButtonClicked()
    {
        gameObject.SetActive(false); //TopPanel
        languageSelectionPanel.SetActive(true);
        bottomPanel.SetActive(false);
        contentPanel.SetActive(false);
    }
}
