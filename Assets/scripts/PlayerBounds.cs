using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float minX = cam.transform.position.x - camWidth;
        float maxX = cam.transform.position.x + camWidth;
        float minY = cam.transform.position.y - camHeight;
        float maxY = cam.transform.position.y + camHeight;

        // 🔥 Clamp player inside camera
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
