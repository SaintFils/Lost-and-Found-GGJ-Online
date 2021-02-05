using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    public Rigidbody sock;
    private float speedX=5;

    private void Start()
    {
        sock = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        sock.velocity = new Vector3(Input.GetAxis("Horizontal") * speedX, sock.velocity.y, sock.velocity.z);
    }

}
