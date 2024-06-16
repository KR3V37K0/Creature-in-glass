using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimGif : MonoBehaviour
{
    public Sprite[] frame;
    private float framePerSecond = 3f;

    private Image image = null;
    private Renderer render = null;

    void Awake()
    {
        image = GetComponent<Image>();
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        float index = Time.time * framePerSecond;
        index = index % frame.Length;

        image.sprite = frame[(int)index];

    }
}
