using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParticles : PlayerSystem
{
    [SerializeField] private ParticleSystem smokeParticles;
    [SerializeField] private ParticleSystem flameParticles;

    protected override void Awake()
    {
        base.Awake();

        smokeParticles.Stop();
        flameParticles.Stop();
    }

    private void OnEnable()
    {
        player.Settings.events.OnMouseDown += OnMoving;
    }

    private void OnDisable()
    {
        player.Settings.events.OnMouseDown -= OnMoving;
    }

    private void OnMoving(bool moving)
    {
        if (moving)
        {
            smokeParticles.Play();
            flameParticles.Play();
        } else
        {
            smokeParticles.Stop();
            flameParticles.Stop();
        }
    }
}
