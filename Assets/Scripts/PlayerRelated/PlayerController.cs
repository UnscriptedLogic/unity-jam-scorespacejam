using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[DisallowMultipleComponent]

//The head of operations for the player. Scripts modify and get their variables through this script
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSettingsSO settings;
    [SerializeField] private Rigidbody2D rb2d;

    public PlayerSettingsSO Settings => settings;
    public Rigidbody2D Rb2d => rb2d;
}
