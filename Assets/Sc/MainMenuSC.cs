using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Xml.Linq;
//using UnityEngine.UIElements;

public class MainMenuSC : MonoBehaviour
{
    [Header("Скрипты | Scripts")]
    [SerializeField] SaveLoadSC SaveLoader;
    [SerializeField] TextReaderSC TextReader;

    [Header("Панели | Panels")]
    [SerializeField] GameObject Panel_NewGame;
    [SerializeField] GameObject Panel_LoadGame;
    [SerializeField] GameObject Panel_Settings;

    [Header("'Новая Игра' | 'New Game'")]
    [SerializeField] TMP_InputField Input_Name;
    [Header("'Загрузка' | 'Load'")]
    [SerializeField] GameObject SaveSlot;
    List<SaveSCO> Saves=new List<SaveSCO>();
    void Start()
    {
        TextReader=GetComponent<TextReaderSC>();
        SaveLoader=GetComponent<SaveLoadSC>();
        CloseAllCanvas();
        transform.Find("Canvas_MainMenu").gameObject.SetActive(true);
        transform.Find("Canvas_MainMenu/__Buttons").gameObject.SetActive(true);

    }
    private void CloseAllCanvas()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
        Panel_NewGame.SetActive(false);
        Panel_LoadGame.SetActive(false);
        Panel_Settings.SetActive(false);

        Panel_LoadGame.transform.Find("Panel_Back/__INFO").gameObject.SetActive(false);
    }



    //_______________________________________________________MAIN MENU
    public void Button_NewGame()
    {
        transform.Find("Canvas_MainMenu/__Buttons").gameObject.SetActive(false);
        Panel_NewGame.SetActive(true);
    }
    public void Button_LoadGame()
    {
        transform.Find("Canvas_MainMenu/__Buttons").gameObject.SetActive(false);
        Panel_LoadGame.SetActive(true);
        Load_Data();

    }
    public void Button_Settings()
    {
        transform.Find("Canvas_MainMenu/__Buttons").gameObject.SetActive(false);
        Panel_Settings.SetActive(true);
    }
    public void Button_Exit()
    {
        Application.Quit();
        Debug.Log("EXIT");
    }



    //_______________________________________________________NEW GAME
    public void Button_Cancel_NewGame()
    {
        transform.Find("Canvas_MainMenu/__Buttons").gameObject.SetActive(true);
        CloseAllCanvas();
        transform.Find("Canvas_MainMenu").gameObject.SetActive(true);
    }
    public void Button_StartNewGame()
    {
        string Name = Input_Name.text;
        if (Name.Length > 0) 
        { 
            Debug.Log("New Game has been startet with " + Name);
            SaveSCO newSave = new SaveSCO();
            newSave.SetName(Name);
            TextReader.Save_File = newSave;

            CloseAllCanvas();
            transform.Find("Canvas_Dialogue").gameObject.SetActive(true);
            transform.Find("Canvas_Scene").gameObject.SetActive(true);

            SaveLoader.Save(newSave);

            TextReader.StartReading();

            
        }
        else Debug.Log("Please Enter Name");
    }



    //_______________________________________________________LOAD GAME
    public void Load_Data()
    {
        Saves=SaveLoader.LoadAll();
        for (int n=0;n<Saves.Count;n++) 
        {
            SaveSlot.GetComponent<SaveSlotSC>().numb = n;
            SaveSlot.transform.Find("Text_Number").GetComponent<TMP_Text>().text = '0'+n.ToString();
            SaveSlot.transform.Find("Text_Name").GetComponent<TMP_Text>().text = Saves[n].GetName();
            SaveSlot.transform.Find("Text_Chapter").GetComponent<TMP_Text>().text = Saves[n].GetChapter();

            Instantiate(SaveSlot, Panel_LoadGame.transform.Find("Panel_Back/Scroll View/Viewport/Content"));
        }
    }
    public void Button_SaveSlot(int numb)
    {
        GameObject info = Panel_LoadGame.transform.Find("Panel_Back/__INFO").gameObject;
        Debug.Log("Press " + numb);

        string h, m;
        m = (Saves[numb].GetTime() % 60).ToString();
        if (m.Length < 2) m = "0" + m;
        h = (Saves[numb].GetTime() / 60).ToString();
        if (h.Length < 2) h = "0" + h;

        info.transform.Find("Text_Name").GetComponent<TMP_Text>().text = Saves[numb].GetName();
        info.transform.Find("Text_Time").GetComponent<TMP_Text>().text = "Time: "+h+":"+m;

        foreach(Sprite spr in SaveLoader.Save_Sprites)
        {
            if (spr.name == Saves[numb].GetPortrait()) 
            { 
                info.transform.Find("Image_Portrait").GetComponent<Image>().sprite = spr; 
                break;
            }
        }      
        info.SetActive(true);
    }
    public void Button_StartLoadGame()
    {

    }
}
