using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Panel")]
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TMP_Text scoreText;

    [HideInInspector]
    public int Score = 0;

    public DoofusDiary doofusDiary;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        Time.timeScale = 0f;
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void IncreaseScore()
    {
        Score++;
    }

    private void Update()
    {
        scoreText.text = Score.ToString();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }
}