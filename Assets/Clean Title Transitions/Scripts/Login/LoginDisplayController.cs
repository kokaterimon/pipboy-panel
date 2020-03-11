using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginDisplayController : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "INGRESE PASSWORD";
    }

    // Update is called once per frame
    void Update()
    {
        showKey();
    }

    void showKey()
    {
        GetComponent<Text>().text = LoginController.playerCode;
        //currentText.text = ClickControl.playerCode;
    }
}
