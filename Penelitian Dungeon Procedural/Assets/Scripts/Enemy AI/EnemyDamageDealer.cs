using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    bool canDealDamage;
    public bool hitRegistered;
    List<GameObject> hasDealtDamage;

    [SerializeField] float weaponLength;
    AIAgent agent;
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
        agent = GetComponentInParent<AIAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;
            int layerMask = 1 << 3;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                hitRegistered = true;
                if (hit.transform.TryGetComponent(out PlayerHealth player) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    if (agent.attackLeft || agent.attackRight)
                    {
                        player.TakeDamage(agent.config.normalAttackDamage);
                    }
                    else if (agent.heavyAttack)
                    {
                        player.TakeDamage(agent.config.heavyAttackDamage);
                    }
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
            }
            else
            {
                hitRegistered = false;
            }
        }
    }
    public void EnemyStartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage.Clear();
    }
    public void EnemyEndDealDamage()
    {
        canDealDamage = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
