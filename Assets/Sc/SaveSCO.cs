using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Save", menuName = "Save File", order = 53)] // 2
public class SaveSCO : ScriptableObject
{
    [SerializeField] private string Name;
    [SerializeField] private Sprite Portrait;
    [SerializeField] private int Time;//save min
    [SerializeField] private string Last_CheckPoint;
    [SerializeField] private string Chapter;
    List<string> Bool_Name = new List<string>();
    List<bool> Bool_Value = new List<bool>();

    public string GetName() { return Name; }
    public Sprite GetPortrait() { return Portrait; }
    public int GetTime() { return Time; }
    public string GetLastCheckPoint() { return Last_CheckPoint; }
    public List<string> GetBoolName() { return Bool_Name; }
    public List<bool> GetBoolValue() { return Bool_Value; }



    public void SetName(string name) { Name = name; }
    public void SetPorteit(Sprite image) { Portrait = image; }
    public void SetTime(int min) { Time = min; }
    public void SetLastCheckPoint(string point) { Last_CheckPoint = point; }
    public void SetBoolName(List<string> names) { Bool_Name = names; }
    public void SetBoolValue(List<bool> values) { Bool_Value = values; }
    

}
