﻿using UnityEngine;

public class Entity : MonoBehaviour, ITakeHits
{
    [SerializeField] private int _maxHealth = 5;

    public int Health { get; private set; }

    private void OnEnable()
    {
        Health = _maxHealth;
    }

    public void TakeHit(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Die();
        }
        else
        {
            HandleNonLeathalHit();
        }
    }

    private void HandleNonLeathalHit()
    {
        Debug.Log("Took non-lethal damage");
    }

    private void Die()
    {
        Debug.Log("Died");
    }
}