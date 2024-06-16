using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButtonsSC : MonoBehaviour
{
    [SerializeField] GameObject Canvas;
    [SerializeField] TextReaderSC TextReader;
    
    public void Statue(string animal)
    {
        switch (animal)
        {
            case "cat":
                Debug.Log("MEOW");
                break;
            case "fox":
                Debug.Log("AWW");
                break;
            case "owl":
                Debug.Log("UUUU");
                break;
        }
    }
}
