using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform _player;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x + 5, 0, -10);
    }
}
