using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerTest : MonoBehaviour
{
    [SerializeField]
    float _duration;
    Material targetMat;
    private bool _isSit;
    float Timer = 5.0f;
    Color color1, color2;

    void Start()
    {
        color1 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        color2 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }


    void Update()
    {
        Color color = Color.Lerp(color1, color2, Timer);
        Timer += Time.deltaTime / _duration;
        Camera.main.backgroundColor = color;
    }
}
