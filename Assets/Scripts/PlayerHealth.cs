using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    PlayerData data;
    ChangeColor colorChanger;

    float currentHealth;

    private void Start()
    {
        data = GetComponent<PlayerMovement>().GetData();
        colorChanger = GetComponentInChildren<ChangeColor>();

        currentHealth = data.maxHealth;
    }

    public override void TakeDamage(float damage, int bulletColorIndex)
    {
        if (bulletColorIndex == colorChanger.GetCurrentColor())
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
