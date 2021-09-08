using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlook_habilities : MonoBehaviour
{
    [Header("habilities unlook")]
    public static bool sword_attack = false;
    public static bool dash = false;
    public static bool shurikens = false;
    public GameObject player_habilites;
    private void Update()
    {
        DontDestroyOnLoad(player_habilites);
    }
}
