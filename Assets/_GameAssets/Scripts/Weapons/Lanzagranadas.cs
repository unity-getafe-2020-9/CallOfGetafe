using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzagranadas : Weapon
{
    public override void Shoot()
    {
        base.Shoot();
        print("DISPARANDO LANZAGRANADAS");
    }
}
