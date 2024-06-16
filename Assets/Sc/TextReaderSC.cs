/*using System.Collections;
using System.Collections.Generic;
using System.IO;*/
using System.Text.RegularExpressions;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using TMPro;
/*using UnityEngine.Windows;
using System.Text;
using System;
using Unity.VisualScripting;*/

public class TextReaderSC : MonoBehaviour
{

        [Header("Персонажи | Characters")]
    [SerializeField] CharacterSCO[] Char_Arr;

        [Header("Интерфейс | UI")]
    [SerializeField] TMP_Text Text_Character_Name;
    [SerializeField] TMP_Text Text_Dialog;

        [Header("Тексты | Texts Files")]
    [SerializeField] TextAsset[] Files;

    private int current = -1;
    [SerializeField] string[] Lines;

        [Header("Текущее Сохранение | Current Save")]
    public SaveSCO Save_File;
    //[SerializeField] List<string> Bool_Name = new List<string>();
    //[SerializeField] List<bool> Bool_Value = new List<bool>();

    private bool Waiting = false;


    public void StartReading()
    {
        Char_Arr[1].SetName(Save_File.GetName());
        Lines = Regex.Split(Files[0].text, @"\r?\n");
        Reader();
    }
    void Update()
    {
        if (Waiting)
        {
            if (Input.anyKeyDown)
            {
                Waiting = false;
                Reader();
            }
        }
    }
    void Reader()
    {
        current++;
        string line= Lines[current];
        string command = line;
        string content = "";

        if (line.Contains(":")) 
        { 
            command = line.Substring(0, line.IndexOf(":")); 
            content = line.Substring(line.IndexOf(":")+1, line.Length - line.IndexOf(":")-1); 
        }
               /* Debug.Log("строка: no "+(current+1)+"  "+line);
                Debug.Log("команда: " + command);
                Debug.Log("контент: " + content);
                Debug.Log("----------");*/
        switch (command)
        {
            case "Speaker":
                Speaker_Change(content);
                break;
            case "Text":
                Text_Change(content);
                break;
            case "AddImage":
                int dot = line.IndexOf(".");
                string n= content.Substring(0,dot); 
                string p=content.Substring(dot,content.Length - dot);
                Image_Add(n,p);
                break;
            case "ChangeImage":
                dot = line.IndexOf(".");
                n = content.Substring(0, dot);
                p = content.Substring(dot, content.Length - dot);
                Image_Change(n, p);
                break;
            case "DeleteImage":
                Image_Delete(content);
                break;
            case "ChangeGG":
                GG_Change_Image(content);
                break;
            case "ChangeBack":
                Back_Change(content);
                break;
            case "Wait":
                Wait();
                break;
            case "Jump":
                Jump(content);
                break;
            case "JumpToNumb":
                JumpToNumb(int.Parse(content));
                break;
            case "JumpFile":
                Jump_to_File(content);
                break;
            case "Point":
                CheckPoint(content);
                break;
            case "Choice":
                dot = line.IndexOf(".");
                n = content.Substring(0, dot);
                p = content.Substring(dot, content.Length - dot);
                Choice(n,p);
                break;
            case "if":
                string[] ar = content.Split(".");
                bool b = false;
                if (ar[1]=="True")b=true;
                IF(ar[0],b,ar[2],ar[3]);
                break;
            case "bool":
                ar = content.Split(".");
                b = false;
                if (ar[1] =="True")b=true;
                Boolean(ar[0], b);
                break;
            case "Chapter":
                Chapter(content);
                break;
            case "Port":
                SavesPortrait(content);
                break;
            case "Save":
                Save();
                break;
            case "Scene":
                Scene(content);
                break;
            case "Dialog":
                Dialog_Canvas(content);
                break;
            default:Debug.Log("COMMAND DONT FOUND. LINE: " + line);Reader(); break;
        }
    }
    void Speaker_Change(string Name)
    {
        Text_Character_Name.text = Name;      
        Text_Character_Name.color = Color.white;

        if (Name == "GG") { Text_Character_Name.text = Char_Arr[1].GetName(); Text_Character_Name.color = Char_Arr[1].GetColor(); Text_Character_Name.alpha = 1f; }
        else
        {
            for (int i = 0; i < Char_Arr.Length; i++)
            {
                if (Name == Char_Arr[i].name)
                {
                    Debug.Log("YES");

                    Text_Character_Name.text = Char_Arr[i].GetName();
                    Text_Character_Name.color = Char_Arr[i].GetColor();
                    Text_Character_Name.alpha = 1f;
                    break;
                }
                else Debug.Log(Char_Arr[i].name == Name);
            }
        }
        Reader();
    }
    void Text_Change(string Text)
    {    
        if(Text.Contains("{GG}")) Text = Text.Replace("{GG}", Char_Arr[1].GetName());
        Text_Dialog.text = Text;
        Reader();
    }
    void Image_Add(string Name,string Pic)
    {
        Reader();
    }
    void Image_Change(string Name, string Pic)
    {
        Reader();
    }
    void Image_Delete(string Name)
    {
        Reader();
    }
    void GG_Change_Image(string Pic)
    {
        Reader();
    }
    void Back_Change(string Pic)
    {
        Reader();
    }
    void Wait()
    {
        Waiting = true;
    }
    void Jump(string check)
    {
        Reader();
    }
    void JumpToNumb(int Numb)
    {
        Reader();
    }
    void Jump_to_File(string Name)
    {
        Reader();
    }
    void Choice(string Name,string Content)
    {
        Reader();
    }
    void CheckPoint(string Name)
    {
        Reader();
    }
    void IF(string Name,bool value,string T,string F)
    {
        Reader();
    }
    void Boolean(string Name, bool value)
    {
        Reader();
    }
    void Chapter(string Name)
    {
        Reader();
    }
    void SavesPortrait(string Name)
    {
        Reader();
    }
    void Save()
    {
        Reader();
    }
    void Scene(string name)
    {
        Reader();
    }
    void Dialog_Canvas(string active)
    {
        Reader();
    }
}
