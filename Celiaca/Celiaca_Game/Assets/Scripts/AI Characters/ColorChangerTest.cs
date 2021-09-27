using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangerTest : MonoBehaviour
{
    [SerializeField]
    float _duration;
    public RawImage _rawImage;
    private bool _isSit;
    float Timer = 5.0f;
    public Color color1, color2;

    void Start()
    {
        color1 = new Color(0f, 1f, 0);
        color2 = new Color(1f, 0f, 0f);
    }


    void Update()
    {
        Color color = Color.Lerp(color1, color2, Timer);
        Timer += Time.deltaTime / _duration;
        Color _rawImage = color;
    }
}
