using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemyAnimated : SmartEnemy
{
    public Animator animator;

    protected override void Update()
    {
        base.Update();
        EvaluarEstado();
    }
    private void EvaluarEstado()
    {
        Vector3 target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        if (CalcularDistanciaAlPlayer() <= distanciaSeguimiento)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
