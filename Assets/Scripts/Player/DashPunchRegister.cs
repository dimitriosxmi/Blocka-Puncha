using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPunchRegister : MonoBehaviour
{
    [SerializeField] Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TileWalls")
        {
            player.StopDashPunch();
        }
    }
}
