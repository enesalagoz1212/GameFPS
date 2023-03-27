using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public int speed = 3;
    const float gravity = 9.8f;
    
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveCharacter();
    }
    Vector3 moveVektor;
    private void MoveCharacter()
    {
        moveVektor = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        moveVektor = transform.TransformDirection(moveVektor);
        if (!characterController.isGrounded)
        {
            moveVektor.y -= Time.deltaTime * gravity;
        }
        characterController.Move(moveVektor);
    }
}
