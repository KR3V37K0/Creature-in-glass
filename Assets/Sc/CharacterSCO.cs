using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Char", menuName = "Character", order = 52)] // 1
public class CharacterSCO : ScriptableObject
{
    [SerializeField]private string Name;
    [SerializeField] private Color Color;
    [SerializeField] private Color TextColor;
    [SerializeField] private Font Font;
    [SerializeField] private Sprite[] Sprites;

    public string GetName() { return Name; }
    public void SetName(string name) { Name = name; }
    public Color GetColor() { return Color; }
    public Color GetTextColor() { return TextColor; }
    public Font GetFont() { return Font; }
    public Sprite GetSprite(string Name) 
    {
        foreach (Sprite sprite in Sprites)
        {
            if (sprite.name == Name) { return sprite; }
        }
        return  null;
    }
}
