using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    bool used = false;
    [Tooltip("0 = Add jump, 1 = Add dash, 2 = Free jump, 3 = Yellow key, 4 = Red key, 5 = Blue key")]
    public int idOfInteractableObject = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.name == "player" && used == false)
        {
            Color backupColor = transform.GetComponent<SpriteRenderer>().color;
            transform.GetComponent<SpriteRenderer>().color = new Vector4(backupColor.r, backupColor.g, backupColor.b, 0.3f);
            used = true;

            switch (idOfInteractableObject)
            {
                case 0:
                    PlayerController.plyrCon.numberOfJumps++;     
                    break;

                case 1:
                    PlayerController.plyrCon.numberOfDashes++;
                    break;

                case 2:
                    PlayerController.plyrCon.Jump(900);
                    break;

                case 3:
                    PlayerController.plyrCon.yellowKeys++;
                    Destroy(gameObject);
                    break;

                case 4:
                    PlayerController.plyrCon.redKeys++;
                    Destroy(gameObject);
                    break;

                case 5:
                    PlayerController.plyrCon.blueKeys++;
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
