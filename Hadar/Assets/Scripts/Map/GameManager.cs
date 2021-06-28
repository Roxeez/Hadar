using System;
using Entity;
using Extension;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Map
{
    public class GameManager : MonoBehaviour
    {
        private Start start;
        private Finish finish;
        private Player player;
        private MapBorder mapBorder;
        private Checkpoint[] checkpoints;

        private Vector2 startPoint;
        private Vector2 respawnPoint;
        
        private void Awake()
        {
            start = GetObject<Start>();
            finish = GetObject<Finish>();
            player = GetObject<Player>();
            mapBorder = GetObject<MapBorder>();
            checkpoints = GetObjects<Checkpoint>(optional: true);

            finish.Reached += OnFinishReached;
            mapBorder.CollidedWithPlayer += OnMapBorderCollidedWithPlayer;
            
            checkpoints.ForEach(checkpoint =>
            {
                checkpoint.Reached += OnCheckpointReached;
            });
        }

        private void Start()
        {
            startPoint = new Vector2
            {
                x = start.transform.position.x + 1,
                y = start.transform.position.y - 1.3f
            };

            respawnPoint = startPoint;
            player.transform.position = startPoint;
        }

        private void OnFinishReached()
        {
            player.transform.position = startPoint;
        }

        private void OnCheckpointReached(Checkpoint checkpoint)
        {
            respawnPoint = checkpoint.transform.position;
        }

        private void OnMapBorderCollidedWithPlayer()
        {
            player.transform.position = respawnPoint;
        }

        private static T GetObject<T>(bool optional = false) where T : Object
        {
            var value = FindObjectOfType<T>();
            if (value == default && !optional)
            {
                throw new UnityException($"Can't found required object {typeof(T).Name} in scene");
            }

            return value;
        }

        private static T[] GetObjects<T>(bool optional = false) where T : Object
        {
            var value = FindObjectsOfType<T>();
            if (value == default && !optional)
            {
                throw new UnityException($"Can't found required object {typeof(T).Name} in scene");
            }

            return value ?? Array.Empty<T>();
        }
    }
}
