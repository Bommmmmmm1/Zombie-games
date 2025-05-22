using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject gameOverScreen;

    void Awake()
    {
        Instance = this;
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true); // tampilkan panel game over
    }
}
