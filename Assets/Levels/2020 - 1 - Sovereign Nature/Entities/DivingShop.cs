using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingShop : Poppable
{
    [SerializeField] protected ParticleSystem incomeParticles = null;

    public override void PopIn()
    {
        base.PopIn();
        incomeParticles.Play();
    }
}
