using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyExtension
{
    public Rigidbody rigidBody;
    public Collider collider;

    public void init(Rigidbody rigidBody, Collider collider)
    {
        this.rigidBody = rigidBody;
        this.collider = collider;
    }

    public bool isGrounded()
    {
        float groundDistance = collider.bounds.extents.y;
        return Physics.Raycast(rigidBody.gameObject.transform.position, -Vector3.up, groundDistance + 0.1f);
    }
}
