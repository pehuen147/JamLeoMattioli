using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.UI;

public class PlayerHealth : Health
{
    PlayerData data;
    ChangeColor colorChanger;

    [SerializeField] RectTransform healthBar;

    float currentHealth;


    Vector2 defaultSize;

    private void Start()
    {
        data = GetComponent<PlayerMovement>().GetData();
        colorChanger = GetComponentInChildren<ChangeColor>();

        currentHealth = data.maxHealth;

        defaultSize = healthBar.sizeDelta;

    }

    public override void TakeDamage(float damage, int bulletColorIndex)
    {
        if (bulletColorIndex == colorChanger.GetCurrentColor())
            currentHealth -= damage;

        if (currentHealth <= 0)
            Death();

        Debug.Log(currentHealth);

        healthBar.sizeDelta = new Vector2(defaultSize.x / data.maxHealth * currentHealth
                                                        , defaultSize.y);

    }

    public override void Death()
    {
        SceneManager.LoadScene(GameManager.deathSceneName, LoadSceneMode.Single);
    }

}
