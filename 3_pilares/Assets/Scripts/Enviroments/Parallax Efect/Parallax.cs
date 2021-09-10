using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Parallax Settings")]
    private float length, starpos;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        starpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(starpos + dist, transform.position.y, transform.position.z);
        if (temp > starpos + length) starpos += length;
        else if (temp < starpos - length) starpos -= length;
    }
}
