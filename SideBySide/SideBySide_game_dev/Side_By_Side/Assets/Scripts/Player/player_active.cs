using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_active : MonoBehaviour
{
    [Header("Control Of Players")]
    [SerializeField]private Player_move_1 player_1;
    [SerializeField]private Player_move_2 player_2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (player_1.player_1)
            {
                player_1.player_1 = false;
                player_2.player_2 = true;
            }
            else if (!player_1.player_1)
            {
                player_1.player_1 = true;
                player_2.player_2 = false;
            }
        }
    }
}

