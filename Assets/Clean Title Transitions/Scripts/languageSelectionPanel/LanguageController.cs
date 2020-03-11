using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageController : MonoBehaviour
{
    [Header("PANELS TO HIDE AND SHOW")]
    public GameObject languageSelectionPanel;
    public GameObject topPanel;
    public GameObject bottomPanel;
    public GameObject contentPanel;

    [Header("FOR BUTTONS SELECTION")]
    public GameObject spanishShadow;
    public GameObject englishShadow;

    [Header("FOR CLOSE BUTTON")]
    public GameObject closeButton;

    [Header("LANGUAGE PARAMS")]
    public string resourceFile = "script";
    public string defaultlanguage = "en";
    //public string overridelanguage = "";

    [Header("TEXT INTO LANGUAGE")]
    public Text titleText;

    [Header("ALL TEXTS ON THE SYSTEM")]
    //Menu
    public Text menuChalecos;
    public Text menuExplosivos;
    public Text menuBaterias;
    public Text menuReferencias;
    public Text menuTelefono;
    
    //Chalecos
    public Text chaleco1Name;
    public Text chaleco1DescTitle;
    public Text chaleco1CompTitle;
    public Text chaleco1Desc;
    public Text chaleco1Comp;

    public Text chaleco2Name;
    public Text chaleco2DescTitle;
    public Text chaleco2CompTitle;
    public Text chaleco2Desc;
    public Text chaleco2Comp;

    public Text chaleco3Name;
    public Text chaleco3DescTitle;
    public Text chaleco3CompTitle;
    public Text chaleco3Desc;
    public Text chaleco3Comp;

    public Text chaleco4Name;
    public Text chaleco4DescTitle;
    public Text chaleco4CompTitle;
    public Text chaleco4Desc;
    public Text chaleco4Comp;

    public Text chaleco5Name;
    public Text chaleco5DescTitle;
    public Text chaleco5CompTitle;
    public Text chaleco5Desc;
    public Text chaleco5Comp;
    //Explosivos
    public Text explosivo1Name;
    public Text explosivo1Desc;
    public Text explosivo1DeactModeTitle;
    public Text explosivo1DeactMode;

    public Text explosivo2Name;
    public Text explosivo2Desc;
    public Text explosivo2DeactModeTitle;
    public Text explosivo2DeactMode;

    public Text explosivo3Name;
    public Text explosivo3Desc;
    public Text explosivo3DeactModeTitle;
    public Text explosivo3DeactMode;

    public Text explosivo4Name;
    public Text explosivo4Desc;
    public Text explosivo4DeactModeTitle;
    public Text explosivo4DeactMode;
    //Baterías
    public Text bateria1Name;
    public Text bateria1Desc;
    public Text bateria1DeactModeTitle;
    public Text bateria1DeactMode;

    public Text bateria2Name;
    public Text bateria2Desc;
    public Text bateria2DeactModeTitle;
    public Text bateria2DeactMode;

    public Text bateria3Name;
    public Text bateria3Desc;
    public Text bateria3DeactModeTitle;
    public Text bateria3DeactMode;
    //Referencias
    public Text referenciasSecredTitle;
    public Text referenciasSecredText;
    public Text referenciasTimeElapseText;
    //Telefono
    public Text telefonoTextCalling;
    public Text telefonoNumberNotFound;

    #region Language
    private Dictionary<string, string[]> lines = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);


    public string[] GetText(string textKey)
    {
        string[] tmp = new string[] { };
        if (lines.TryGetValue(textKey, out tmp))
            return tmp;

        return new string[] { "<color=#ff00ff>MISSING TEXT FOR '" + textKey + "'</color>" };
    }

    //private void Awake()
    //{
    //    var json = LoadScriptFile();
    //    var voText = JsonUtility.FromJson<LanguageOverText>(json);

    //    foreach (var t in voText.lines)
    //    {
    //        lines[t.key] = t.line;
    //    }
    //}

    private void loadLanguage(string lang)
    {
        var json = LoadScriptFile(lang);
        var voText = JsonUtility.FromJson<LanguageOverText>(json);

        foreach (var t in voText.lines)
        {
            lines[t.key] = t.line;
        }
    }

    private string LoadScriptFile(string lang)
    {
        var countrycode = LanguageHelper.Get2LetterISOCodeFromSystemLanguage();
        if (!string.IsNullOrEmpty(lang))
        {
            countrycode = lang;
        }

        var codes = new string[] { countrycode, defaultlanguage };
        foreach (var code in codes)
        {
            string scriptFileName = resourceFile + "." + code;
            var textAsset = Resources.Load<TextAsset>(scriptFileName);
            if (textAsset != null)
            {
                return textAsset.text;
            }
        }
        return "";
    }
    #endregion

    public void OnCloseButtonClicked()
    {
        //gameObject.SetActive(false); //language Selection panel
        languageSelectionPanel.SetActive(false);
        topPanel.SetActive(true);
        bottomPanel.SetActive(true);
        contentPanel.SetActive(true);
    }

    public void OnSpanishButtonClicked()
    {
        spanishShadow.SetActive(true);
        englishShadow.SetActive(false);
        closeButton.SetActive(true);
        loadLanguage("es");
        //titleText.text = GetText("language-selection")[0];
        ToTraduceAll();
        PhoneControler.espEng = false;        
    }

    public void OnEnglishButtonClicked()
    {
        spanishShadow.SetActive(false);
        englishShadow.SetActive(true);
        closeButton.SetActive(true);
        loadLanguage("en");
        //titleText.text = GetText("language-selection")[0];
        ToTraduceAll();
        PhoneControler.espEng = true;
    }

    private void ToTraduceAll()
    {
        menuChalecos.text = GetText("menu-chalecos")[0];
        menuExplosivos.text = GetText("menu-explosivos")[0];
        menuBaterias.text = GetText("menu-baterias")[0];
        menuReferencias.text = GetText("menu-referencias")[0];
        menuTelefono.text = GetText("menu-telefono")[0];

        chaleco1Name.text = GetText("chaleco1-nombre")[0];
        chaleco1Desc.text = GetText("chaleco1-desc")[0];
        chaleco1Comp.text = GetText("chaleco1-comp")[0];
        chaleco1DescTitle.text = GetText("desc")[0];
        chaleco1CompTitle.text = GetText("comp")[0];

        chaleco2Name.text = GetText("chaleco2-nombre")[0];
        chaleco2Desc.text = GetText("chaleco2-desc")[0];
        chaleco2Comp.text = GetText("chaleco2-comp")[0];
        chaleco2DescTitle.text = GetText("desc")[0];
        chaleco2CompTitle.text = GetText("comp")[0];

        chaleco3Name.text = GetText("chaleco3-nombre")[0];
        chaleco3Desc.text = GetText("chaleco3-desc")[0];
        chaleco3Comp.text = GetText("chaleco3-comp")[0];
        chaleco3DescTitle.text = GetText("desc")[0];
        chaleco3CompTitle.text = GetText("comp")[0];

        chaleco4Name.text = GetText("chaleco4-nombre")[0];
        chaleco4Desc.text = GetText("chaleco4-desc")[0];
        chaleco4Comp.text = GetText("chaleco4-comp")[0];
        chaleco4DescTitle.text = GetText("desc")[0];
        chaleco4CompTitle.text = GetText("comp")[0];

        chaleco5Name.text = GetText("chaleco5-nombre")[0];
        chaleco5Desc.text = GetText("chaleco5-desc")[0];
        chaleco5Comp.text = GetText("chaleco5-comp")[0];
        chaleco5DescTitle.text = GetText("desc")[0];
        chaleco5CompTitle.text = GetText("comp")[0];

        explosivo1Name.text = GetText("explosivo1-nombre")[0];
        explosivo1Desc.text = GetText("explosivo1-desc")[0];
        explosivo1DeactModeTitle.text = GetText("explosivo-deactmode-title")[0];
        explosivo1DeactMode.text = GetText("explosivo1-deactmode")[0];        

        explosivo2Name.text = GetText("explosivo2-nombre")[0];
        explosivo2Desc.text = GetText("explosivo2-desc")[0];
        explosivo2DeactModeTitle.text = GetText("explosivo-deactmode-title")[0];
        explosivo2DeactMode.text = GetText("explosivo2-deactmode")[0];

        explosivo3Name.text = GetText("explosivo3-nombre")[0];
        explosivo3Desc.text = GetText("explosivo3-desc")[0];
        explosivo3DeactModeTitle.text = GetText("explosivo-deactmode-title")[0];
        explosivo3DeactMode.text = GetText("explosivo3-deactmode")[0];

        explosivo4Name.text = GetText("explosivo4-nombre")[0];
        explosivo4Desc.text = GetText("explosivo4-desc")[0];
        explosivo4DeactModeTitle.text = GetText("explosivo-deactmode-title")[0];
        explosivo4DeactMode.text = GetText("explosivo4-deactmode")[0];

        bateria1Name.text = GetText("bateria1-nombre")[0];
        bateria1Desc.text = GetText("bateria1-desc")[0];
        bateria1DeactModeTitle.text = GetText("bateria-deactmode-title")[0];
        bateria1DeactMode.text = GetText("bateria1-deactmode")[0];

        bateria2Name.text = GetText("bateria2-nombre")[0];
        bateria2Desc.text = GetText("bateria2-desc")[0];
        bateria2DeactModeTitle.text = GetText("bateria-deactmode-title")[0];
        bateria2DeactMode.text = GetText("bateria2-deactmode")[0];

        bateria3Name.text = GetText("bateria3-nombre")[0];
        bateria3Desc.text = GetText("bateria3-desc")[0];
        bateria3DeactModeTitle.text = GetText("bateria-deactmode-title")[0];
        bateria3DeactMode.text = GetText("bateria3-deactmode")[0];

        referenciasSecredTitle.text = GetText("referencias-secredtext-title")[0];
        referenciasSecredText.text = GetText("referencias-secredtext-desc")[0];

        //Otros textos
        ReferenciasControl.playerCode = GetText("referencias-ingreselaclave")[0];
        ReferenciasControl.ingreseLaClave = GetText("referencias-ingreselaclave")[0];
        ReferenciasControl.claveIncorrecta = GetText("referencias-claveincorrecta")[0];
        ReferenciasControl.textQuedan = GetText("referencias-textquedan")[0];
        ReferenciasControl.textIntentos = GetText("referencias-textintentos")[0];
        titleText.text = GetText("language-selection")[0];
        referenciasTimeElapseText.text = GetText("referencias-timeelapsetext")[0];
        telefonoTextCalling.text = GetText("telefono-textcalling")[0];
        telefonoNumberNotFound.text = GetText("telefono-numbernotfound")[0];
    }

}
