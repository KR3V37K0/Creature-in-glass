using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;

public class TextReaderSC : MonoBehaviour
{
    [SerializeField] CharacterSCO[] Char_Arr;
    private StreamReader File = new StreamReader("Assets/Resources/TXT/TEST.txt");


    void Start()
    {
        //Debug.Log(File.ReadLine());
        Reader();
    }
    void Update()
    {
        
    }

    void Reader()
    {
        string line = File.ReadLine();
        string command = line;
        string content = "";
        Debug.Log(line.Contains(":"));
        if (line.Contains(":")) 
        { 
            command = line.Substring(0, line.IndexOf(":")); 
            content = line.Substring(line.IndexOf(":"), line.Length - line.IndexOf(":")); 
        }
        //Debug.Log(line.Substring(line.IndexOf(":"),line.Length- line.IndexOf(":")));
        Debug.Log("строка: "+line);
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
                Jump(int.Parse(content));
                break;
            case "JumpFile":
                Jump_to_File(content);
                break;
            case "Choice":
                dot = line.IndexOf(".");
                n = content.Substring(0, dot);
                p = content.Substring(dot, content.Length - dot);
                Choice(n,p);
                break;
            default:Debug.Log("COMMAND DONT FOUND. LINE: " + line); break;
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
    void Jump(int Numb)
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
}
