using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject endScreen;
    public Text scoreText;

    public void EndGameWithScore(float time)
    {
        Time.timeScale = 0f; // Freeze time
        endScreen.SetActive(true);
        scoreText.text = $"Score: {time:F2} seconds";
    }

    public void ReplayScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}