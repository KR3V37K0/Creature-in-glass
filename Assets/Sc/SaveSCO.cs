using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSCO
{
    [SerializeField] private string Name;
    [SerializeField] private string Portrait;
    [SerializeField] private int Time;//save min
    [SerializeField] private string Last_CheckPoint;
    [SerializeField] private string Chapter;
    [SerializeField] List<string> Bool_Name = new List<string>();
    [SerializeField] List<bool> Bool_Value = new List<bool>();


    public string GetName() { return Name; }
    public string GetPortrait() { return Portrait; }
    public int GetTime() { return Time; }
    public string GetLastCheckPoint() { return Last_CheckPoint; }
    public string GetChapter() { return Chapter; }
    public List<string> GetBoolName() { return Bool_Name; }
    public List<bool> GetBoolValue() { return Bool_Value; }



    public void SetName(string name) { Name = name; }
    public void SetPorteit(string imageName) { Portrait = imageName; }
    public void SetTime(int min) { Time = min; }
    public void SetLastCheckPoint(string point) { Last_CheckPoint = point; }
    public void SetChapter(string cha) { Chapter = cha; }
    public void SetBoolName(List<string> names) { Bool_Name = names; }
    public void SetBoolValue(List<bool> values) { Bool_Value = values; }
    

}
