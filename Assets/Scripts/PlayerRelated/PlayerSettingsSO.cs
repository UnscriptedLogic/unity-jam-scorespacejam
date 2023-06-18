using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Settings", menuName = "ScriptableObjects/Create New Player Settings")]
public class PlayerSettingsSO : ScriptableObject
{
    [SerializeField] private string playerName = "Player 1";
    [SerializeField] private Color playerColor = Color.green;

    public PlayerEvents events;

    public string PlayerName => playerName;
    public Color PlayerColor => playerColor;
}
