using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagesCombatController : CombatController
{
    [SerializeField] private GameObject projectileGO;
    [SerializeField] private Transform projectileSpawnArea;
    [SerializeField] private float projectileForce;


    public override void CheckCombatInput()
    {
        if (this.GetComponent<Player>().isAttacking)
        {
            this.GetComponent<Player>().canMove = false;
            return;
        }
        else { this.GetComponent<Player>().canMove = true; }

        if (Input.GetKeyDown(KeyCode.J))
        {
            this.GetComponent<Player>().canMove = false;

            if (combatEnabled)
            {
                gotInput = true;
            }
        }
    }

    public override void CheckAttacks()
    {
        if (gotInput)
        {
            if (!this.GetComponent<Player>().isAttacking)
            {
                gotInput = false;
                this.GetComponent<Player>().isAttacking = true;

                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", this.GetComponent<Player>().isAttacking);

                anim.SetBool("attack1", true);
                isFirstAttack = true;
            }
        }
    }

    public void Shoot()
    {
        projectileSpawnArea.rotation = this.GetComponent<Player>().isFacingRight ? Quaternion.identity : Quaternion.Euler(0, 180, 0);

        GameObject newProjectile = Instantiate(projectileGO, projectileSpawnArea.position, projectileSpawnArea.rotation);
        Projectile projectile = newProjectile.GetComponent<Projectile>();

        newProjectile.GetComponent<Rigidbody2D>().velocity = projectileSpawnArea.right * projectileForce;
    }
}