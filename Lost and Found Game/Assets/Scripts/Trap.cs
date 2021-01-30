using System;
using UnityEngine;

namespace ProcessNamespace
{
    public class Trap : MonoBehaviour
    {
        [Header("Trap settings")]
        [SerializeField] private float trapDamage = 0.5f;
        [SerializeField] private float pushForce; // настройка силы толчка после получения дамага на трапе
     
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerInput>())
            {
                other.gameObject.GetComponent<Destructable>()?.ApplyDamage(trapDamage);
                other.gameObject.GetComponent<Moveable>()?.Push(pushForce); 
                Debug.Log(other.gameObject.GetComponent<Destructable>()._currentHealthPoint); // для тестирования
            }
        }
    }
}