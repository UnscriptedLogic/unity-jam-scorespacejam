using System;
using System.Collections;
using UnityEngine;

public struct PlayerEvents
{
    public Vector2 worldMousePos;

    public Action<Vector2> OnMouseMoved;
    public Action<bool> OnMouseDown;
}
