using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public int damage = 10;
    public float attackRange = 1.5f;
    public float attackDelay = 1.0f;
    private Animator animator;
    private float lastAttackTime;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if the player triggers the attack and if enough time has passed since the last attack
        if (Input.GetButtonDown("Fire1") && Time.time > lastAttackTime + attackDelay)
        {
            lastAttackTime = Time.time;
            animator.SetTrigger("Attack");
            StartCoroutine(DoMeleeAttack());
        }
    }

    IEnumerator DoMeleeAttack()
    {
        // wait for the attack animation to finish playing
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // detect all enemies within range of the attack
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (Collider hitCollider in hitColliders)
        {
            // check if the hit collider has an EnemyHealth component and apply damage if it does
            //EnemyHealth enemyHealth = hitCollider.GetComponent<EnemyHealth>();
            //if (enemyHealth != null)
            {
                //    enemyHealth.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
