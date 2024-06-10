using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotSC : MonoBehaviour
{
    public int numb;
    private MainMenuSC sc;
    private void Start()
    {
        sc = FindObjectOfType<Camera>().GetComponent<MainMenuSC>();
    }
    public void Click()
    {
        sc.Button_SaveSlot(numb);
    }
}
