using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnscriptedLogic.Currency;

public class ShipMovement : PlayerSystem
{
    [SerializeField] private float initializedSpeed = 150f;

    private bool canMove;
    private CurrencyHandler movementHandler;

    protected override void Awake()
    {
        base.Awake();

        movementHandler = new CurrencyHandler(initializedSpeed, max: 99f);
    }

    private void FixedUpdate()
    {
        if (!canMove) return;

        //player.Rb2d.MovePosition(transform.position + (transform.right * movementHandler.Current * Time.deltaTime));
        player.Rb2d.AddForce(transform.right * movementHandler.Current * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    private void CanMove(bool canMove) => this.canMove = canMove;

    private void OnEnable()
    {
        player.Settings.events.OnMouseDown += CanMove;
    }

    private void OnDisable()
    {
        player.Settings.events.OnMouseDown -= CanMove;
    }
}