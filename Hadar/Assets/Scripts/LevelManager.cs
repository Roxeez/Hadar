using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Tilemap border;
    [SerializeField] private GameObject spawn;
    [SerializeField] private Player player;
    
    public Player Player => player;
    public GameObject Spawn => spawn;
    public Checkpoint LastCheckpoint { get; set; }

    private void Update()
    {
        var position = player.transform.position;

        var tilePosition = border.WorldToCell(new Vector2
        {
            x = position.x,
            y = position.y
        });
        
        if (border.HasTile(tilePosition))
        {
            if (!player.IsFlipped)
            {
                player.Flip();
            }
            
            player.transform.position = LastCheckpoint is null ? spawn.transform.position : LastCheckpoint.transform.position;
        }
    }
}
