using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Tilemap border;
    
    private GameObject player;
    private GameObject respawn;
    
    private SpriteRenderer playerRendered;
    
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        respawn = GameObject.FindWithTag("Respawn");
    }

    private void Start()
    {
        playerRendered = player.GetComponent<SpriteRenderer>();
    }

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
            if (playerRendered.flipX)
            {
                playerRendered.flipX = false;
            }
        
            player.transform.position = respawn.transform.position;
        }
    }
}
