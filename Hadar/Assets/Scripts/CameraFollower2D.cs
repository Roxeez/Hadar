using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower2D : MonoBehaviour
{
    private Camera cam;
    
    [SerializeField] private GameObject target;
    [SerializeField] private Vector2 offset;

    [SerializeField] private Vector2 minimum = Vector2.negativeInfinity;
    [SerializeField] private Vector2 maximum = Vector2.positiveInfinity;
    
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        var targetPosition = target.transform.position;
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
