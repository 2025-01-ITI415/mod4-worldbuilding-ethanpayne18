using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHUD : MonoBehaviour
{
    public Text collectibleText;
    public Text timerText;
    public float startDelay = 5f;

    private float startTime;
    private bool timerStarted = false;
    private int collectedCount = 0;
    private int totalCollectibles = 5;

    void Start()
    {
        collectibleText.text = $"Collectibles: 0 / {totalCollectibles}";
        timerText.text = "Time: 0.00";
        Invoke(nameof(StartTimer), startDelay);
    }

    void Update()
    {
        if (timerStarted)
        {
            float elapsedTime = Time.time - startTime;
            timerText.text = $"Time: {elapsedTime:F2}";
        }
    }

    void StartTimer()
    {
        startTime = Time.time;
        timerStarted = true;
    }

    public void UpdateCollectibleCount()
    {
        collectedCount++;
        collectibleText.text = $"Collectibles: {collectedCount} / {totalCollectibles}";

        if (collectedCount >= totalCollectibles)
        {
            StartCoroutine(RestartSceneWithDelay());
        }
    }

    private System.Collections.IEnumerator RestartSceneWithDelay()
    {
        float finalTime = Time.time - startTime;
        timerText.text = $"Final Time: {finalTime:F2}";

        yield return new WaitForSeconds(3f); // Short delay to show final time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}