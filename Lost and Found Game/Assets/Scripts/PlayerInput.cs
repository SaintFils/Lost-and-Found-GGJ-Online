using UnityEngine;

namespace ProcessNamespace
{
    public class PlayerInput : MonoBehaviour
    {
        private Moveable _moveable;
     
        private void Awake()
        {
            _moveable = GetComponent<Moveable>();
        }

        private void Update()
        {
            _moveable.Move(Input.GetAxis(AxisManager.HORIZONTAL));
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _moveable.Jump();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _moveable.Dash();
            }
        }
    }
}