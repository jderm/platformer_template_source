using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "player")
        {
            PlayerController.plyrCon.gameObject.SetActive(false);
            GameController.gameCon.Death();
        }
    }
}
