using UnityEngine;
using UnityEngine.SceneManagement;

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

        Debug.Log(currentHealth);

    }

    public override void Death()
    {
        SceneManager.LoadScene(GameManager.deathSceneName, LoadSceneMode.Single);
    }

}
