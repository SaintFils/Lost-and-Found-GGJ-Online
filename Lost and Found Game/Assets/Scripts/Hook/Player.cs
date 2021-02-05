using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GrapplingHook hook;

    private void Update()
    {
            if ( Input.GetMouseButtonDown(0))
            {
                hook.CreateHook();
            }
            else if ( Input.GetMouseButtonUp(0)) 
            {
                hook.DisableHook();
            }
    }
}
