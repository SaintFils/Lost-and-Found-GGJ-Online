using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private HookRaycaster raycast;
    [SerializeField] private HookRender render;
    [SerializeField] private Player player;

    private SpringJoint SJ;


    public void CreateHook() 
    {
        RaycastHit hit = raycast.Raycast();

        if (hit.collider !=null) 
        {
            Vector3 grapplePoint = hit.point;

            SJ = player.gameObject.AddComponent<SpringJoint>();
            SJ.autoConfigureConnectedAnchor = false;
            SJ.connectedAnchor = grapplePoint;

            float grappleDistance = Vector3.Distance(transform.position, grapplePoint);

            SJ.maxDistance = grappleDistance;
            SJ.minDistance = grappleDistance;

            SJ.damper = 10;
            SJ.spring = 5;
        }

    }

    public void DisableHook() 
    {
        Destroy(SJ);
    }
}
