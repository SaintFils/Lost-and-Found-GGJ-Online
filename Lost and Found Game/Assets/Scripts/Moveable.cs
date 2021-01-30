using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProcessNamespace
{
    public class Moveable : MonoBehaviour
    {
        [Header("DefaultMovement")]
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _jumpForce;

        [Header("IsGrounded")]
        [SerializeField] private Transform _isGroundedRaycastPoint; //точка из которой будет происходить проверка на isGrounded, на сцене должна находиться в нижней части персонажа
        [SerializeField] private float _rayCastDistance = 0.1f; 
        private float _rayCastRadius = 0.0f;

        [Header("Dash")]
        [SerializeField] private bool _isDashNow;
        [SerializeField] private float _dashSpeed;
        [SerializeField] private float _dashTime; //как долго объект будет в состоянии дэша

        private float _dashTimer;
        private float _lastInput;
        private Rigidbody _rigidBody;
        private bool _isGrounded;
        private int _isGroundedLayersMask = 1 << 8; //эта штука показывает то, столкновения с какими слоями будут засчитываться при raycast-е, нужно создать слой floor или что-то такое и заменить 4 на порядковый номер нового слоя, слои создаются через саму unity

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void Move(float xInput) //принимает число от -1 до 1 и в зависимости от инпута двигает объект влево или вправо
        {
            if (!_isDashNow)
            {
                _lastInput = xInput; //запоминаем последнее полученное направление, на случай, если игрок будет делать дэш
                _rigidBody.velocity = new Vector3(xInput * _movementSpeed, _rigidBody.velocity.y, 0); //задает скорость по Х, сохраняет скорость по Y
            }
        }

        public void MoveToTarget(Transform target) //двигает объект в направлении к цели, пригодится для летающих и патрулирующих противников
        {
            _rigidBody.velocity = (target.position - transform.position).normalized * _movementSpeed; //находим вектор направления к цели, сокращаем до единичной длинны, увеличиваем в зависимости от скорости, двигаем по нему объект
        }

        public void Jump()
        {
            if (_isGrounded)
            {
                _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0, 0); // сохраняя скорость по Х анулирует скорость по Y перед прыжком (обычно нужно для двойного прыжка, но можно и удалить, если не надо) 
                _rigidBody.AddForce(Vector3.up * _jumpForce); //сила прикладывается вверх
            }
        }

        public void Dash()
        {
            _isDashNow = true;
            _dashTimer = _dashTime; //запускаем таймер, по истечению которого рывок прекратится
        }

        private void Update()
        {
            if (_isDashNow)
            {
                //во время дэша
                _rigidBody.velocity = new Vector3(_lastInput * _dashSpeed, _rigidBody.velocity.y, 0); //двигаем персонажа с увеличенной скоростью без возможности изменить направление
                _dashTimer -= Time.deltaTime; // тикает таймер рывка

                if(_dashTimer <= 0) //чекаем таймер
                {
                    _isDashNow = false;
                }
            }
            
            CheckIsGrounded();
        }

        public void CheckIsGrounded()
        {
            Ray ray = new Ray(_isGroundedRaycastPoint.position, Vector3.down);
            _isGrounded = (Physics.SphereCast(ray, _rayCastRadius, _rayCastDistance, _isGroundedLayersMask)); //пускаем луч, если находим поверхность, принадлежащую нужному слою (например floor) => isgrounded = true
            Debug.Log(_isGrounded);
        }
    }
}