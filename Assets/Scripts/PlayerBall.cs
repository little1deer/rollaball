using System;

namespace RollaBall
{
    public sealed class PlayerBall: Player
    {
        private void Update()
        {
            Move();
            Jump(); 
        }
    }
}