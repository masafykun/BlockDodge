using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    TextMeshProUGUI scoreText;
    TextMeshProUGUI finalScoreText;
    GameObject gameOverPanel;
    float score;
    bool playing;

    void Awake() => Instance = this;

    void Start()
    {
        // Transform.Find searches inactive children too
        var canvas = FindAnyObjectByType<Canvas>()?.transform;
        scoreText      = canvas?.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        gameOverPanel  = canvas?.Find("GameOverPanel")?.gameObject;
        finalScoreText = gameOverPanel?.transform.Find("FinalScoreText")?.GetComponent<TextMeshProUGUI>();

        var btn = gameOverPanel?.transform.Find("RestartButton")?.GetComponent<Button>();
        if (btn != null) btn.onClick.AddListener(Restart);

        BeginGame();
    }

    void BeginGame()
    {
        playing = true;
        score = 0f;
        Time.timeScale = 1f;
        gameOverPanel?.SetActive(false);
    }

    void Update()
    {
        if (!playing) return;
        score += Time.deltaTime;
        if (scoreText) scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    public void GameOver()
    {
        if (!playing) return;
        playing = false;
        Time.timeScale = 0f;
        gameOverPanel?.SetActive(true);
        if (finalScoreText) finalScoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        foreach (var b in FindObjectsByType<FallingBlock>())
            Destroy(b.gameObject);
        var player = FindAnyObjectByType<PlayerController>();
        if (player) player.transform.position = new Vector3(0f, 0.5f, 0f);
        FindAnyObjectByType<BlockSpawner>()?.ResetSpawner();
        BeginGame();
    }

    public bool IsPlaying => playing;
    public float Score => score;
}
