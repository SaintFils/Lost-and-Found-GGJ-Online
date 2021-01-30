using UnityEngine;

namespace ProcessNamespace
{
    public class Trampoline : MonoBehaviour
    {
        [Header("Trampoline settings")]
        [SerializeField] private float pushForce; // настройка силы толчка 
     
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerInput>())
            {
                other.gameObject.GetComponent<Moveable>()?.Push(pushForce);
            }
        }
    }
}