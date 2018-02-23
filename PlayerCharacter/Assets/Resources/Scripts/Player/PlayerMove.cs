using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerMove
{
    // Objects
    public GameObject player;
    public GameObject character;
    public GameObject cameraBaseH;

    public float movementSpeed = 10.0f;
    public float rotationSpeed = 5.0f;

    public void Init(GameObject player, GameObject character, GameObject cameraBaseH)
    {
        this.player = player;
        this.character = character;
        this.cameraBaseH = cameraBaseH;
    }

    public void Move()
    {
        float velocity = Input.GetAxis("Vertical");

        if (velocity != 0.0f)
        {
            Rotate();
            player.transform.position += character.transform.forward * velocity * movementSpeed * Time.deltaTime;
        }
    }

    public void MoveSide()
    {
        float velocity = Input.GetAxis("Horizontal");

        if (velocity != 0.0f)
        {
            Rotate();
            player.transform.position += character.transform.right * velocity * movementSpeed * Time.deltaTime;
        }
    }

    public void Jump()
    {
        if (Input.GetAxis("Jump") != 0f)
        {
            Debug.Log("Jump");
        }
    }

    public void Rotate()
    {
        Quaternion previousRotation = character.transform.localRotation;
        character.transform.localRotation = Quaternion.Slerp(previousRotation, cameraBaseH.transform.localRotation, rotationSpeed * Time.deltaTime);
    }
}
