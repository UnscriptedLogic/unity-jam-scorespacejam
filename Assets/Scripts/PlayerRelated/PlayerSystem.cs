using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An abstract class for player scripts to inherit from to automatically get a reference to the controller
public abstract class PlayerSystem : MonoBehaviour
{
    protected PlayerController player;

    protected virtual void Awake()
    {
        player = GetComponent<PlayerController>();
    }
}
