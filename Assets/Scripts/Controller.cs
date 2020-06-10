﻿using UnityEngine;

public class Controller : MonoBehaviour
{
    public int Index { get; private set; }
    public bool isAssigned { get; set; }

    private string attackButton;
    private string horizontalAxis;
    private string verticalAxis;
    
    public bool attack;
    public bool attackPressed;

    public float horizontal;
    public float vertical;

    private void Update()
    {
        if (!string.IsNullOrEmpty(attackButton))
        {
            attack = Input.GetButton(attackButton);
            attackPressed = Input.GetButtonDown(attackButton);
            horizontal = Input.GetAxis(horizontalAxis);
            vertical = Input.GetAxis(verticalAxis);
        }
    }

    public void SetIndex(int index)
    {
        Index = index;
        attackButton = "Attack" + index;
        horizontalAxis = "Horizontal" + index;
        verticalAxis = "Vertical" + index;
        gameObject.name = "Controller" + Index;
    }

    public bool AnyButtonDown()
    {
        return attack;
    }

    public Vector3 GetDirection()
    {
        return new Vector3(horizontal, 0, -vertical);
    }
}
