using System;
using UnityEngine;

namespace ProcessNamespace
{
    public sealed class GameController : MonoBehaviour
    {
        private ListExecuteObject _interactiveObject; 

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }
    }
}