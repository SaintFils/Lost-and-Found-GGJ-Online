using UnityEngine.SceneManagement;

namespace ProcessNamespace
{
    public sealed class PlayerBoy : PlayerBase
    {
        private void FixedUpdate()
        {
            Move();
            Jump();
        }

        public PlayerBoy(float speed) : base(speed)
        {
        }
        
        
    }
}