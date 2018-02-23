using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMove move;
    [SerializeField] private PlayerLook look;

    public GameObject character;
    public GameObject cameraBaseH;
    public GameObject cameraBaseV;

    void Start()
    {
        move = new PlayerMove();
        look = new PlayerLook();

        move.Init(this.gameObject, this.character, this.cameraBaseH);
        look.Init(this.cameraBaseH, this.cameraBaseV);
    }

    void Update()
    {
        look.LookRotation();
        move.Move();
        move.MoveSide();
        move.Jump();
    }
}
