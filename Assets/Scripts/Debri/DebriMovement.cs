using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebriMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 200;
    [SerializeField] private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d.AddForce(transform.right * movementSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
}
