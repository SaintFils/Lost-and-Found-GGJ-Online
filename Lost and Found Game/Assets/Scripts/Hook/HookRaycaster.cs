using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _grappleMask;
    [SerializeField] private float maxDistance;
    [SerializeField] private Camera _cam;

    public RaycastHit Raycast() 
    {
        RaycastHit hit;
        Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit,maxDistance,_grappleMask);
        return hit;
    }
}
