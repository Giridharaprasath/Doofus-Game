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
    private GameObject pauseMenuPanel;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TMP_Text scoreText;

    [Header("Audio Sources")]
    [SerializeField]
    private AudioSource buttonClick;

    [HideInInspector]
    public int Score = 0;
    [SerializeField]
    public bool canPause;

    [Header("Doofus Diary")]
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
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        canPause = false;
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
        buttonClick.Play();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        canPause = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        canPause = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        buttonClick.Play();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        canPause = true;
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        canPause = false;
    }
}