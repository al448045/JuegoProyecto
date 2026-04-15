using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 cameraOffset;

    private void Start()
    {
        player = GameManager.Instance.player.transform;
        cameraOffset = new Vector3(0, 0, -10);
    }
    void Update()
    {
        transform.position = player.position + cameraOffset;
    }
}
