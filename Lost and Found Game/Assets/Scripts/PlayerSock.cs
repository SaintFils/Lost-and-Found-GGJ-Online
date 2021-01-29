using UnityEngine;


namespace ProcessNamespace
{
    public sealed class PlayerSock : PlayerBase
    {

        private void FixedUpdate()
        {
            Move();
            Jump();
        }

        public PlayerSock(float speed) : base(speed)
        {
        }

    }
}