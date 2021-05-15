using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
