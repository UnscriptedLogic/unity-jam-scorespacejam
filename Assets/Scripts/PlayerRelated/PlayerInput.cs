using UnityEngine;
using UnityEngine.InputSystem;
using Input;
using System;
using UnityEditor.ShaderGraph.Serialization;

[DisallowMultipleComponent]
public class PlayerInput : PlayerSystem
{
    private DefaultControls defaultControls;
    private Vector2 mousePosition;
    private Vector2 mouseDelta;

    protected override void Awake()
    {
        base.Awake();
        defaultControls = new DefaultControls();
    }

    private void OnEnable()
    {
        defaultControls.Enable();
        defaultControls.DefaultMap.Enable();

        defaultControls.DefaultMap.MousePosition.performed += ReadMousePosition;
        defaultControls.DefaultMap.MouseDelta.performed += OnMouseMoved;
        defaultControls.DefaultMap.MouseClick.performed += OnMouseDown;

        defaultControls.DefaultMap.MouseClick.canceled += OnMouseUp;
    }

    private void OnDisable()
    {
        defaultControls.Disable();
        defaultControls.DefaultMap.Disable();

        defaultControls.DefaultMap.MousePosition.performed -= ReadMousePosition;
        defaultControls.DefaultMap.MouseDelta.performed -= OnMouseMoved;
        defaultControls.DefaultMap.MouseClick.performed -= OnMouseDown;

        defaultControls.DefaultMap.MouseClick.canceled -= OnMouseUp;
    }

    private void Update()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePosition);
        player.Settings.events.worldMousePos = worldMousePos;

        //This way we dont make unneccessary event raising when the mouse isn't moving
        //Sqrmagnitdue because it's less computationally expensive
        if (mouseDelta.sqrMagnitude > 0)
        {
            player.Settings.events.OnMouseMoved?.Invoke(worldMousePos);
        }

    }

    private void OnMouseMoved(InputAction.CallbackContext obj)
    {
        mouseDelta = obj.ReadValue<Vector2>();
    }

    private void ReadMousePosition(InputAction.CallbackContext obj)
    {
        mousePosition = obj.ReadValue<Vector2>();
    }

    private void OnMouseDown(InputAction.CallbackContext obj)
    {
        player.Settings.events.OnMouseDown?.Invoke(true);
    }

    private void OnMouseUp(InputAction.CallbackContext obj)
    {
        player.Settings.events.OnMouseDown?.Invoke(false);
    }
}
