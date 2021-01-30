using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProcessNamespace
{
    public class Destructable : MonoBehaviour
    {
        [NonSerialized] public float _currentHealthPoint;
        [Header("FIELD FOR ENEMY")]
        [SerializeField] private float pushForce;
        private float _maxHealthPoint = 3.0f;
        private float _minHealthPoint = 0.0f;

        private void Awake()
        {
            _currentHealthPoint = _maxHealthPoint;
        }

        public void ApplyDamage(float damage)
        {
            _currentHealthPoint -= damage;
            if (_currentHealthPoint <= _minHealthPoint)
            {
                SceneManager.LoadScene(TagManager.SCENE); //респаун, смерть
            }
        }

        public void ApplyHeal(float heal)
        {
            
            if (_currentHealthPoint == _maxHealthPoint)
            {
                return;
            } 
            _currentHealthPoint += heal;
            
            if (_currentHealthPoint > _maxHealthPoint)
            {
                _currentHealthPoint = _maxHealthPoint;
            }
        }
        
        private void OnTriggerEnter(Collider other) //втаптываем врага в землю с помощью коллайдера триггера у него на голове
        {
            if (other.GetComponent<PlayerInput>())
            {
                Destroy(gameObject);
                other.gameObject.GetComponent<Moveable>()?.Push(pushForce);
            }
        }
    }
}