using Script.Enum;
using Script.Extension;
using UnityEngine;

namespace Script.Game.Maps.Trap
{
    public class Spike : MapObject
    {
        protected override void OnCollision(Collider2D other, CollisionSide side)
        {
            if (!other.IsPlayer())
            {
                return;
            }
            
            GameManager.Player.Kill();
        }
    }
}