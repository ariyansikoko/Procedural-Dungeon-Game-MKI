using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public PlayerUI playerUI;
    [HideInInspector] public float currentHealth;
    [HideInInspector] public CombatController combatController;
    public bool TakingDamage;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        playerUI = GetComponentInChildren<PlayerUI>();
        combatController = GetComponent<CombatController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(currentHealth);
    }
    public void TakeDamage(float amount)
    {
        if (!combatController.isBlocking)
        {
            combatController.animator.SetTrigger("TakingDamage");
            currentHealth -= amount;
            playerUI.SetHealthBarPercentage(currentHealth, maxHealth);
            if (currentHealth <= 0.0f)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        Debug.Log("Player Dead");
    }

}
