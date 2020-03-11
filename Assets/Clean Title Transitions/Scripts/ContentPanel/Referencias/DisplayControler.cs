using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayControler : MonoBehaviour
{
    //private Text currentText;
    //private int currenttextSize = 80;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "INGRESE LA CLAVE";
    }

    // Update is called once per frame
    void Update()
    {
        showKey();
    }

    void showKey()
    {
        GetComponent<Text>().text = ReferenciasControl.playerCode;
        //currentText.text = ClickControl.playerCode;
    }
}
