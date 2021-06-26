using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private Camera cam;
    private GameObject player;
    
    [SerializeField] private Vector2 offset;

    [SerializeField] private Vector2 minimum = Vector2.negativeInfinity;
    [SerializeField] private Vector2 maximum = Vector2.positiveInfinity;
    
    private void Awake()
    {
        cam = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        var targetPosition = player.transform.position;
        var nextPosition = new Vector3
        {
            x = targetPosition.x + offset.x,
            y = targetPosition.y + offset.y,
            z = cam.transform.position.z
        };

        if (nextPosition.x > maximum.x)
        {
            nextPosition.x = maximum.x;
        }

        if (nextPosition.x < minimum.x)
        {
            nextPosition.x = minimum.x;
        }
        
        if (nextPosition.y > maximum.y)
        {
            nextPosition.y = maximum.y;
        }

        if (nextPosition.y < minimum.y)
        {
            nextPosition.y = minimum.y;
        }

        cam.transform.position = nextPosition;
    }
}
