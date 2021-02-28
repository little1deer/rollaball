using System;

namespace RollaBall
{
    public sealed class PlayerBall: Player
    {
        private void FixedUpdate()
        {
            Move();
        }

        private void Update()
        {
            Jump();
        }
    }
}