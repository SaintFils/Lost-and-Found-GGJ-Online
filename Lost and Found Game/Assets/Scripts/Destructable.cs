using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProcessNamespace
{
    public class Destructable : MonoBehaviour
    {
        [NonSerialized] public float _currentHealthPoint;
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
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerInput>())
            {
                Destroy(gameObject);
            }
        }

    }
}