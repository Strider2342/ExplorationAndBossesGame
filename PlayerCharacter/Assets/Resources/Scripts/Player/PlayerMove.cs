using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerMove
{
    // Scripts
    private RigidbodyExtension rbExt;

    // Objects
    public GameObject player;
    public GameObject character;
    public GameObject collider;
    public GameObject cameraBaseH;

    public float movementSpeed = 10.0f;
    public float sprintMultiplier = 2.5f;
    public float midAirMultiplier = 0.5f;
    public float rotationSpeed = 5.0f;
    public float jumpSpeed = 25000.0f;

    public void init(GameObject player, GameObject character, GameObject cameraBaseH)
    {
        this.player = player;
        this.character = character;
        this.cameraBaseH = cameraBaseH;

        this.collider = character.transform.FindChild("Collider").gameObject;

        rbExt = new RigidbodyExtension();
        rbExt.init(player.GetComponent<Rigidbody>(), this.collider.GetComponent<Collider>());
    }

    public void move()
    {
        if (getVelocity() != Vector3.zero)
        {
            rotate();
            player.transform.position += getVelocity() * Time.deltaTime;
        }
    }

    public void jump()
    {
        if (Input.GetButtonDown("Jump") && rbExt.isGrounded())
        {
            Vector3 force = character.transform.up * jumpSpeed;
            player.GetComponent<Rigidbody>().AddForce(force);
        }
    }

    public void rotate()
    {
        Quaternion previousRotation = character.transform.localRotation;
        character.transform.localRotation = Quaternion.Slerp(previousRotation, Quaternion.LookRotation(getVelocity()), rotationSpeed * Time.deltaTime);
    }


    Vector3 getVelocity()
    {
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        velocity = cameraBaseH.transform.TransformDirection(velocity);
        velocity.Normalize();
        velocity *= movementSpeed;
        if (!rbExt.isGrounded()) { velocity *= midAirMultiplier; }
        if (Input.GetButtonDown("Sprint")) { velocity *= sprintMultiplier; }

        return velocity;
    }
}
