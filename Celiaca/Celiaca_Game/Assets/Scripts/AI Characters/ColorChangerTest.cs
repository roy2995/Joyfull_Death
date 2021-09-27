using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerTest : MonoBehaviour
{
    [SerializeField]
    float _duration;

    float Timer = 5.0f;
    Color color1, color2;

    void Start()
    {
        color1 = new Color(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1));
        color2 = new Color(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1));
    }

    // Update is called once per frame
    void Update()
    {
        Color color = Color.Lerp(color1, color2, Timer);
        Timer += Time.deltaTime / _duration;
        Camera.main.backgroundColor = color;
    }
}
