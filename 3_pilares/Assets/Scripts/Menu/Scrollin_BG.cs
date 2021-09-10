using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scrollin_BG : MonoBehaviour
{
    [Header("Scrolling Settings")]
    public RawImage Bg;
    public float speed;
    public Vector2 scrollDirection;
    Rect rect;

    private void Start()
    {
        rect = Bg.uvRect;
    }

    private void Update()
    {
        rect.x += scrollDirection.x * speed * Time.deltaTime;
        rect.y += scrollDirection.y * speed * Time.deltaTime;
        Bg.uvRect = rect;
    }
}
