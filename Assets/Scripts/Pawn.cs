using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pawn : MonoBehaviour
{
    [SerializeField] public string Name;

    [SerializeField] public float MaxHealth;
    public float Health
    {
        get => health;
        set
        {
            health = value;
            HPBar.SetValue(Health, MaxHealth);
        }
    }

    private float health;

    [SerializeField] public float Damage;
    [SerializeField] public HPBar HPBar;

    public void Attack(Pawn targetPawn)
    {
        targetPawn.Health = Mathf.Max(targetPawn.Health - Damage, 0.0f);
    }

    public void Init()
    {
        HPBar.Init(MaxHealth);
        Health = MaxHealth;
    }
}
