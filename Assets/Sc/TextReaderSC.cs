using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using TMPro;
using UnityEngine.Windows;

public class TextReaderSC : MonoBehaviour
{
        [Header("Персонажи | Characters")]
    [SerializeField] CharacterSCO[] Char_Arr;

        [Header("Интерфейс | IU")]
    [SerializeField] TMP_Text Character_Name;
    [SerializeField] TMP_Text Dialog;

        [Header("Тексты | Texts Files")]
    [SerializeField] TextAsset[] Files;

    private int current = -1;
    public string[] Lines;


    void Start()
    {
        Lines = Regex.Split(Files[0].text, "\n");
        Reader();
    }
    void Update()
    {
        
    }
    void Reader()
    {
        current++;
        string line=Lines[current];
        string command = line;
        string content = "";

        if (line.Contains(":")) 
        { 
            command = line.Substring(0, line.IndexOf(":")); 
            content = line.Substring(line.IndexOf(":"), line.Length - line.IndexOf(":")); 
        }
                Debug.Log("строка: no "+(current+1)+"  "+line);
                Debug.Log("команда: " + command);
                Debug.Log("контент: " + content);
                Debug.Log("----------");
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
            default:Debug.Log("COMMAND DONT FOUND. LINE: " + line);Reader(); break;
        }
    }
    void Speaker_Change(string Name)
    {
        Reader();
    }
    void Text_Change(string Text)
    {
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
        Reader();
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
}
