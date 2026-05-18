using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;
    public Vector3 cameraOffset;

    public Vector3 maxValue;
    public Vector3 minValue;

    public float cameraHeight;
    public float cameraWidth;

    public Camera camera;

    private void Start()
    {
        player = GameManager.Instance.player.transform;
        cameraOffset = new Vector3(0, 0, -10);

        maxValue = new Vector3(21, 15, 0);
        minValue = new Vector3(-22, -15, 0);

        cameraHeight = camera.orthographicSize;
        cameraWidth = camera.orthographicSize * camera.aspect;
    }
    void Update()
    {

        transform.position = new Vector3(
            Mathf.Clamp(player.position.x, minValue.x + cameraWidth, maxValue.x - cameraWidth),     //x
            Mathf.Clamp(player.position.y, minValue.y + cameraHeight, maxValue.y - cameraHeight),   //y
            cameraOffset.z);                                                                        //z
    }
}
