using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    Rect size;
    public GameObject player;
    Rect gameManagerPositions;
    Vector3 pos;
    public bool cameraLimits = false;
    float xpos;
    float ypos;

    void Start()
    {
        gameManagerPositions = GameController.gameCon.size;
    }
    void Update()
    {
        size.width = -(Camera.main.aspect * 2f * Camera.main.orthographicSize);
        size.height = 2f * Camera.main.orthographicSize;
        size.x = size.width / 2;
        size.y = -(size.height / 2);

        if (cameraLimits)
        {
            if(player == null)
            {
            }

            else
            {
                if (player.transform.position.x >= (gameManagerPositions.x + -size.x) && player.transform.position.x <= ((gameManagerPositions.width - -gameManagerPositions.x) + (size.width - size.x)))
                {
                    xpos = player.transform.position.x;
                }

                if (player.transform.position.y >= (gameManagerPositions.y + -size.y) && player.transform.position.y <= ((gameManagerPositions.height - -gameManagerPositions.y) - (size.height - -size.y)))
                {
                    ypos = player.transform.position.y;
                }

                pos = new Vector3(xpos, ypos, -1);
                transform.position = pos;
            }    
        }

        else if (!cameraLimits)
        {
            if (player == null)
            {
            }

            else
            {
                Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y, -1);
                transform.position = pos;
            }
        }
    }

    void OnDrawGizmos()
    {
        DrawGizmoRect(size, Color.green);
    }

    void DrawGizmoRect(Rect rect, Color color)
    {
        Gizmos.color = color;

        rect.x = transform.position.x - (rect.width / 2);
        rect.y = transform.position.y - (rect.height / 2);

        Vector3 topLeft = new Vector3(rect.xMin, rect.yMax, transform.position.z);
        Vector3 botLeft = new Vector3(rect.xMin, rect.yMin, transform.position.z);
        Vector3 topRight = new Vector3(rect.xMax, rect.yMax, transform.position.z);
        Vector3 botRight = new Vector3(rect.xMax, rect.yMin, transform.position.z);

        Gizmos.DrawLine(topLeft, botLeft);
        Gizmos.DrawLine(topRight, botRight);
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(botLeft, botRight);
    }
}
