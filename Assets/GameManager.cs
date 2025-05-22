using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    void Start() // <- Huruf besar
    {
        gameOverScreen.SetActive(false); // hide game over panel at start
        UpdateKillCount(); // <- Pastikan tidak typo
    }

    void UpdateKillCount() // <- Tambahkan fungsi ini
    {
        Debug.Log("UpdateKillCount dipanggil.");
        // Tambahkan logika menghitung kill di sini jika ada
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Load the game Scene
    }

    public void GameOver()
    {
        UIManager.Instance.ShowGameOver();
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // pastikan kamu punya scene bernama MainMenu
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true); // show the game over UI
    }
}
