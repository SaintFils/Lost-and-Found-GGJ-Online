using System;
using UnityEngine;

namespace ProcessNamespace
{
    public class Trap : MonoBehaviour
    {
        private float _trapDamage = 0.5f;
     
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerInput>())
            {
                other.gameObject.GetComponent<Destructable>().ApplyDamage(_trapDamage);
                Debug.Log(other.gameObject.GetComponent<Destructable>()._currentHealthPoint);
                other.gameObject.GetComponent<Moveable>().Push();
            }
        }
    }
}