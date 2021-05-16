using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(GameManager.mainSceneName, LoadSceneMode.Single);
    }
}
