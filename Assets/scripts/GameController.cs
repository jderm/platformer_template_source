using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class GameController : MonoBehaviour
{
    public static GameController gameCon;
    public Rect size;
    public bool paused = false;

    public TMP_Text yKeyText;
    public TMP_Text bKeyText;
    public TMP_Text rKeyText;
    public TMP_Text dashText;
    public TMP_Text jumpText;

    public GameObject gameUI;
    public GameObject pauseUI;
    public GameObject deathUI;

    private void Awake()
    {
        gameCon = this;
    }

    void OnDrawGizmos()
    {
        DrawGizmoRect(size, Color.red);
    }

    void DrawGizmoRect(Rect rect, Color color)
    {
        Gizmos.color = color;

        Vector3 topLeft = new Vector3(rect.xMin, rect.yMax, transform.position.z);
        Vector3 botLeft = new Vector3(rect.xMin, rect.yMin, transform.position.z);
        Vector3 topRight = new Vector3(rect.xMax, rect.yMax, transform.position.z);
        Vector3 botRight = new Vector3(rect.xMax, rect.yMin, transform.position.z);

        Gizmos.DrawLine(topLeft, botLeft);
        Gizmos.DrawLine(topRight, botRight);
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(botLeft, botRight);
    }

    public void Death()
    {
        if(pauseUI.activeSelf)
        {
            paused = false;
            pauseUI.SetActive(false);
            gameUI.SetActive(false);
            deathUI.SetActive(true);
        }

        else
        {
            gameUI.SetActive(false);
            deathUI.SetActive(true);
        }
        
    }

    public void Respawn()
    {
        deathUI.SetActive(false);
        gameUI.SetActive(true);
        PlayerController.plyrCon.gameObject.SetActive(true);
        Vector3 respawnPosition = new Vector3(-85, -7, 0);
        PlayerController.plyrCon.gameObject.transform.position = respawnPosition;
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if(paused == false && Input.GetKeyDown(KeyCode.Escape))
        {
            if(!deathUI.activeSelf)
            { 
                gameUI.SetActive(false);
                pauseUI.SetActive(true);
                paused = true;
                Time.timeScale = 0;
            }

            else
            {
                
            }
            
        }

        else if(paused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            gameUI.SetActive(true);
            pauseUI.SetActive(false);
            paused = false;
            Time.timeScale = 1;
        }

        yKeyText.text = "Y keys: " + PlayerController.plyrCon.yellowKeys.ToString();
        bKeyText.text = "B keys: " + PlayerController.plyrCon.blueKeys.ToString();
        rKeyText.text = "R keys: " + PlayerController.plyrCon.redKeys.ToString();
        dashText.text = "Dashes: " + PlayerController.plyrCon.numberOfDashes.ToString();
        jumpText.text = "Jumps: " + PlayerController.plyrCon.numberOfJumps.ToString();
}
}
