using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class UI_ : MonoBehaviour
{   
    public TMP_Dropdown resolutionDropdown;
    public GameObject PauseMenu, MainMenu, Help, Options;

    Resolution[] resolutions_defoult;
    bool isFullScreen = true, isHelpMain = false, isOptionsMain = false;
    
    void Start()
    {
        List<string> options = new List<string>();
        int current = 0;
        #region Resolution
        resolutionDropdown.ClearOptions();
        resolutions_defoult = Screen.resolutions;
        for (int i = 0; i < resolutions_defoult.Length; i++)
        {
            options.Add(resolutions_defoult[i].width + " x " + resolutions_defoult[i].height);
            if (resolutions_defoult[i].width == Screen.currentResolution.width && resolutions_defoult[i].height == Screen.currentResolution.height) { current = i; }
        }//Заполняет множественный выбор разрешений + Устанавливает индекс текущего разрешения (current)   
        resolutionDropdown.AddOptions(options);//Добавляет все разрешения в DropDown
        resolutionDropdown.value = current;//Устанавливает текущее разрешение экрана
        ResolutionChange(resolutionDropdown.value);//Устанавливает текущее разрешение экрана
        #endregion
    }
    public void ResolutionChange(int ResolutionID)
    {
        Screen.SetResolution(resolutions_defoult[ResolutionID].width, resolutions_defoult[ResolutionID].height, isFullScreen);
        //Панели и их инициализация
        #region Panels
        GameObject MainMenu = this.transform.Find("MainMenu").gameObject;
        GameObject PauseMenu = this.transform.Find("PauseMenu").gameObject;
        GameObject OptionMenu = this.transform.Find("Options").gameObject;
        GameObject Game = this.transform.Find("Game").gameObject;
        GameObject Quit = this.transform.Find("QuitAsk").gameObject;
        #endregion

        #region MainMenu
            GameObject MMenu_Play = MainMenu.transform.Find("Play").gameObject;
            MMenu_Play.transform.position = new Vector3(MMenu_Play.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.25f, 0);
            GameObject MMenu_Options = MainMenu.transform.Find("Options").gameObject;
            MMenu_Options.transform.position = new Vector3(MMenu_Play.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.2f, 0);
            GameObject MMenu_Titrs = MainMenu.transform.Find("Titrs").gameObject;
            MMenu_Titrs.transform.position = new Vector3(MMenu_Play.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.15f, 0);
            GameObject MMenu_Help = MainMenu.transform.Find("Help").gameObject;
            MMenu_Help.transform.position = new Vector3(MMenu_Play.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.1f, 0);
            GameObject MMenu_Quit = MainMenu.transform.Find("Quit").gameObject;
            MMenu_Quit.transform.position = new Vector3(MMenu_Play.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.05f, 0);
        #endregion

        #region PauseMenu
            GameObject PauseMenu_Play = PauseMenu.transform.Find("Play").gameObject;
            PauseMenu_Play.transform.position = new Vector3(PauseMenu_Play.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.2f, 0);
            GameObject PauseMenu_Options = PauseMenu.transform.Find("Options").gameObject;
            PauseMenu_Options.transform.position = new Vector3(PauseMenu_Options.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.15f, 0);
            GameObject PauseMenu_Back = PauseMenu.transform.Find("Back").gameObject;
            PauseMenu_Back.transform.position = new Vector3(PauseMenu_Back.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.1f, 0);
            GameObject PauseMenu_Help = PauseMenu.transform.Find("Help").gameObject;
            PauseMenu_Help.transform.position = new Vector3(PauseMenu_Help.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.05f, 0);
        #endregion

        #region Options
            GameObject OptionMenu_Back = OptionMenu.transform.Find("Back").gameObject;
            OptionMenu_Back.transform.position = new Vector3(OptionMenu_Back.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.25f, 0);
            GameObject OptionMenu_Sensetivity = OptionMenu.transform.Find("Sensetive").gameObject;
            OptionMenu_Sensetivity.transform.position = new Vector3(OptionMenu_Sensetivity.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.15f, 0);
            GameObject OptionMenu_Resolution = OptionMenu.transform.Find("Resolution").gameObject;
            OptionMenu_Resolution.transform.position = new Vector3(OptionMenu_Resolution.GetComponent<RectTransform>().sizeDelta.x / 2 + 20, Screen.height * 0.05f, 0);
        #endregion

        #region Game
            GameObject Game_Subtitles = Game.transform.Find("Subtitles").gameObject;
            Game_Subtitles.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 0.4f, Screen.height * 0.1f);
            Game_Subtitles.transform.position = new Vector3(Screen.width / 2, Screen.currentResolution.height * 0.1f, 0);
        #endregion

        #region QuitAsk
            GameObject Quit_True = Quit.transform.Find("Yes").gameObject;
            Quit_True.transform.position = new Vector3(Screen.width * 0.75f, Screen.height * 0.5f, 0);
            GameObject Quit_False = Quit.transform.Find("No").gameObject;
            Quit_False.transform.position = new Vector3(Screen.width * 0.25f, Screen.height * 0.5f, 0);
        #endregion

        #region MenuAsk
        #endregion

    }//Устанавливает разрешение экрана и производит оптимизацию
    public void Windowed(bool value)
    {
        isFullScreen = value;
        Screen.fullScreen = value;
    }//Устанавливает Оконный / Полноэкранный режим
    public void Quit()
    { Application.Quit(); }//Выходит из игры
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void HELP_TRUE() { isHelpMain = true; }
    public void HELP_FALSE() { isHelpMain = false; }
    public void HELP_BACK()
    {
        if (isHelpMain == true) { MainMenu.SetActive(true); Help.SetActive(false); }
        if (isHelpMain == false) { PauseMenu.SetActive(true); Help.SetActive(false); }
    }

    public void OPTION_TRUE() { isOptionsMain = true; }
    public void OPTION_FALSE() { isOptionsMain = false; }
    public void OPTION_BACK()
    {
        if (isOptionsMain == true) { MainMenu.SetActive(true); Options.SetActive(false); }
        if (isOptionsMain == false) { PauseMenu.SetActive(true); Options.SetActive(false); }
    }
}
