using UnityEngine;

namespace ProcessNamespace
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("Camera settings")]
        [SerializeField] private float damping = 1.5f;
        [SerializeField] private bool faceLeft;
        private Transform _player;
        private int _lastX;

        public Vector2 offset = new Vector2(2f, 1f);
        private void Start ()
        {
            offset = new Vector2(Mathf.Abs(offset.x), offset.y);
            FindPlayer(faceLeft);
        }

        public void FindPlayer(bool playerFaceLeft)
        {
            _player = GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform;
            _lastX = Mathf.RoundToInt(_player.position.x);
            if(playerFaceLeft)
            {
                transform.position = new Vector3(_player.position.x - offset.x, _player.position.y + offset.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(_player.position.x + offset.x, _player.position.y + offset.y, transform.position.z);
            }
        }

        private void LateUpdate () 
        {
            if(_player)
            {
                int currentX = Mathf.RoundToInt(_player.position.x);
                if(currentX > _lastX) faceLeft = false; else if(currentX < _lastX) faceLeft = true;
                _lastX = Mathf.RoundToInt(_player.position.x);

                Vector3 target;
                if(faceLeft)
                {
                    target = new Vector3(_player.position.x - offset.x, _player.position.y + offset.y, transform.position.z);
                }
                else
                {
                    target = new Vector3(_player.position.x + offset.x, _player.position.y + offset.y, transform.position.z);
                }
                Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
                transform.position = currentPosition;
            }
        }
    }
}