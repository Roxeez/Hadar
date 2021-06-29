using Entities;
using Maps;
using Maps.Objects;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneUtility = Utility.SceneUtility;

/// <summary>
/// This manager is here to manage basics aspects of the game (respawn, change map etc..)
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Current Map being played
    /// </summary>
    public Map Map { get; private set; }
    
    /// <summary>
    /// Currently played Player object
    /// </summary>
    public Player Player { get; private set; }
    
    /// <summary>
    /// Latest checkpoint took by Player (can be null if none)
    /// </summary>
    public Checkpoint Checkpoint { get; set; }

    /// <summary>
    /// Level manager used to change levels
    /// </summary>
    public LevelManager LevelManager { get; set; }
    
    private void Awake()
    {
        Map = SceneUtility.GetSceneObject<Map>();
        Player = SceneUtility.GetSceneObject<Player>();
        LevelManager = SceneUtility.GetSceneObject<LevelManager>();
    }

    private void Start()
    {
        Player.Position = Map.Spawn.SpawnPoint;
    }

    /// <summary>
    /// Make the player respawn to map spawn or latest checkpoint
    /// </summary>
    public void Respawn()
    {
        if (Player.IsFlipped)
        {
            Player.Flip();
        }
        
        Player.Position = Checkpoint != null ? Checkpoint.SpawnPoint : Map.Spawn.SpawnPoint;
    }
    
    public void ChangeLevel()
    {
        Player.CanMove = false;
        LevelManager.ChangeLevel();
    }
}
