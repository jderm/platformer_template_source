using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    bool used = false;
    public bool endTrigg = false;
    public int dash;
    public int jump;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.name == "player" && used == false)
        {
            used = true;

            PlayerController.plyrCon.numberOfJumps = jump;
            PlayerController.plyrCon.numberOfDashes = dash;

            if(endTrigg == true)
            {
                
            }
        }
    }
}
