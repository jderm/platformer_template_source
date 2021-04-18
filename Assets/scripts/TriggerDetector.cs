using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public int side;
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(side)
        {
            case 0:
                PlayerController.plyrCon.trigTop = true;
                break;

            case 1:
                PlayerController.plyrCon.trigBot = true;
                if(PlayerController.plyrCon.numberOfJumps < 2)
                {
                    PlayerController.plyrCon.numberOfJumps = 2;
                }

                else if(PlayerController.plyrCon.numberOfJumps >= 2)
                {
                }
                
                if(PlayerController.plyrCon.numberOfDashes < 1)
                {
                    PlayerController.plyrCon.numberOfDashes = 1;
                }

                else if (PlayerController.plyrCon.numberOfDashes >= 1)
                {
                }
                    break;

            case 2:
                PlayerController.plyrCon.trigLeft = true;
                break;

            case 3:
                PlayerController.plyrCon.trigRight = true;
                break;
        }

        Debug.Log("Trigger Enter: " + side);
        Debug.Log("Trigger Enter: " + other.name);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (side)
        {
            case 0:
                PlayerController.plyrCon.trigTop = false;
                break;

            case 1:
                PlayerController.plyrCon.trigBot = false;
                break;

            case 2:
                PlayerController.plyrCon.trigLeft = false;
                break;

            case 3:
                PlayerController.plyrCon.trigRight = false;
                break;
        }
        Debug.Log("Trigger Exit: " + side);
        Debug.Log("Trigger Exit: " + other.name);
    }
}
