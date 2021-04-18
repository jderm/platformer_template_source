using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    bool used = false;
    [Tooltip("0 = Yellow doors, 1 = Red doors, 2 = Blue doors")]
    public int idOfDoors = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "player" && used == false)
        {
            switch(idOfDoors)
            {
                case 0:
                    if (PlayerController.plyrCon.yellowKeys > 0)
                    {
                        used = true;
                        PlayerController.plyrCon.yellowKeys--;
                        Destroy(gameObject);
                    }
                    break;

                case 1:
                    if (PlayerController.plyrCon.redKeys > 0)
                    {
                        used = true;
                        PlayerController.plyrCon.redKeys--;
                        Destroy(gameObject);
                    }
                    break;

                case 2:
                    if (PlayerController.plyrCon.blueKeys > 0)
                    {
                        used = true;
                        PlayerController.plyrCon.blueKeys--;
                        Destroy(gameObject);
                    }
                    break;
            }
        }
    }
}
