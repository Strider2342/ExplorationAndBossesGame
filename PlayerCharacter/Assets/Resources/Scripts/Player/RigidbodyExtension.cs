using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyExtension
{
    public Rigidbody rigidBody;

    public void Init(Rigidbody rigidBody)
    {
        this.rigidBody = rigidBody;
    }

    public bool isGrounded(Collider collider)
    {
        float groundDistance = collider.bounds.extents.y;
        return Physics.Raycast(rigidBody.gameObject.transform.position, -Vector3.up, groundDistance + 0.1f);
    }
}
