using UnityEngine;

public class PlayerHealth : Health
{
    PlayerData data;

    float currentHealth;

    private void Start()
    {
        data = GetComponent<PlayerMovement>().GetData();
        currentHealth = data.maxHealth;
    }

    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Death();

    }

    public override void Death()
    {
        Debug.Log("Muere");
    }

}
