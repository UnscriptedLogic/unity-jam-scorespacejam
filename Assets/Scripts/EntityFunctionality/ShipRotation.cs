using UnityEngine;
using UnscriptedLogic.Currency;

public class ShipRotation : PlayerSystem
{
    private Vector2 direction;
    private Vector2 previousPosition;


    private void OnEnable()
    {
        player.Settings.events.OnMouseMoved += RotateToDirection;
    }

    private void OnDisable()
    {
        player.Settings.events.OnMouseMoved -= RotateToDirection;   
    }

    private void Update()
    {
        if (IsPlayerMoving(previousPosition))
        {
            RotateToDirection(player.Settings.events.worldMousePos);
        }

        previousPosition = transform.position;
    }

    private void RotateToDirection(Vector2 direction)
    {
        direction = (new Vector3(direction.x, direction.y, 0) - transform.position).normalized;
        transform.right = direction; //x axis is considered the front in the 2d world.
    }

    private bool IsPlayerMoving(Vector2 previousPosition) => (Vector2)transform.position != previousPosition;
}
