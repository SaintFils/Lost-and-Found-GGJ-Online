using System;
using UnityEngine;

namespace ProcessNamespace
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();

        /*private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag(TagManager.PLAYER))
            {
                Debug.Log("АЙАЙАЙ");
                return;
            }
            Interaction();
            Debug.Log("До уничтожения");
            Destroy(gameObject);
            Debug.Log("После уничтожения");
        }*/

     
    }
}