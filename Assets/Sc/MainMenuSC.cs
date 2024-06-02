using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuSC : MonoBehaviour
{
    [SerializeField] private TMP_InputField Input_Name;
    [SerializeField] private GameObject Panel_NewGame;
    void Start()
    {
        CloseAllCanvas();
        transform.Find("Canvas_MainMenu").gameObject.SetActive(true);
    }
    private void CloseAllCanvas()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
        Panel_NewGame.SetActive(false);
    }

    //_______________________________________________________MAIN MENU
    public void Button_NewGame()
    {
        transform.Find("Canvas_MainMenu/__Buttons").gameObject.SetActive(false);
        Panel_NewGame.SetActive(true);
    }
    public void Button_LoadGame()
    {

    }
    public void Button_Settings()
    {

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
        Panel_NewGame.SetActive(false);
    }
    public void Button_StartNewGame()
    {
        string Name = Input_Name.text;
        if(Name.Length>0) Debug.Log("New Game has been startet with "+Name);
        else Debug.Log("Please Enter Name");
    }
}
