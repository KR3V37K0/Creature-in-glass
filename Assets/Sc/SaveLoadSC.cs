//using System.Collections;
using System.Collections.Generic;
//using System.Xml.Linq;
using UnityEngine;
//using UnityEngine.Profiling;
//using UnityEngine.SocialPlatforms.Impl;
using System.IO;
using System;
using System.Xml.Linq;
using UnityEngine.Profiling;
using UnityEngine.SocialPlatforms.Impl;

public class SaveLoadSC : MonoBehaviour
{
    [SerializeField] int CurrentSave = 0;
    public Sprite[] Save_Sprites;
    private void Start()
    {
        if (Directory.Exists(Application.dataPath + "/SAVES") == false) Directory.CreateDirectory(Application.dataPath + "/SAVES");
    }
    public void Save(SaveSCO save)
    {
        Debug.Log(save.GetName() + " saving");

        string[] files = Directory.GetFiles(Application.dataPath + "/SAVES");
        int files_Count = CurrentSave;
        if (CurrentSave == 0)
        {
            foreach (string file in files)
            {
                if (file[file.Length - 1] != 'a') files_Count++;
            }
        }
        CurrentSave= files_Count;

        string json_settings = JsonUtility.ToJson(save);

        File.WriteAllText(Application.dataPath + "/SAVES/" + files_Count + "_save.json", json_settings);
        Debug.Log(save.GetName() + " save");
    }
    public List<SaveSCO> LoadAll()
    {
        List<SaveSCO> all_DATA = new List<SaveSCO>();

        string[] files = Directory.GetFiles(Application.dataPath + "/SAVES");

        int files_Count = 0;
        foreach (string file in files)
        {
            if (file[file.Length - 1] != 'a') files_Count++;
        }
        for (int n = 0; n < files_Count; n++)
        {
            string json_setting = File.ReadAllText(Application.dataPath + "/SAVES/" + n + "_save.json");
            SaveSCO data = JsonUtility.FromJson<SaveSCO>(json_setting);

            all_DATA.Add(data);
        }
        return all_DATA;
    }

    public void setCurrentSave(int n) { CurrentSave = n; }
}
