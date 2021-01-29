using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProcessNamespace
{
    public class PlayerBase : MonoBehaviour
    {
        public float force;
        protected bool IsOnFloor = false;
        public float speed;
        public float currentPlayerHealthPoint;
        private readonly float _maxPlayerHealthPoint = 3.0f;
        private readonly float _minPlayerHealthPoint = 0.0f;
        protected Rigidbody PlayerRigidbody;
        

        protected PlayerBase(float speed)
        {
            this.speed = speed;
        }
        
        private void Start()
        {
            PlayerRigidbody = GetComponent<Rigidbody>();
        }
        protected void Move()
        {
            var moveHorizontal = Input.GetAxis(AxisManager.HORIZONTAL);
            //var moveVertical = Input.GetAxis("Vertical");
            
            Vector3 movement = new Vector3(moveHorizontal, 0.0f,0.0f);
            
            PlayerRigidbody.AddForce(movement * speed);
        }
        
        private void OnCollisionStay(Collision other)
        {
            if (other.collider.CompareTag(TagManager.FLOOR)) IsOnFloor = true;
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.collider.CompareTag(TagManager.FLOOR)) IsOnFloor = false;
        }
        
        protected void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) & IsOnFloor)
            {
                PlayerRigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
        }

        internal void TakeDamage(float damageAmount)
        {
            currentPlayerHealthPoint -= damageAmount;
            if (currentPlayerHealthPoint <= _minPlayerHealthPoint)
            {
                SceneManager.LoadScene(TagManager.SCENE); //реализация респауна и чекпоинтов
            }
        }

        internal void TakeHeal(float healAmount)
        {
            Debug.Log(currentPlayerHealthPoint); //проверка на максимальное хп
            if (currentPlayerHealthPoint >= _maxPlayerHealthPoint)
            {
                return;
            }
            currentPlayerHealthPoint += healAmount;
            Debug.Log(currentPlayerHealthPoint + "after"); //проверка на максимальное хп
        }

    }
}