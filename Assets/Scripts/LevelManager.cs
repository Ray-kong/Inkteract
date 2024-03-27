using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float levelDuration = 10.0f; // Duration of the level
    public Text levelTimer; // UI Text to display the timer
    public Text scoreText; // UI Text to display the score
    //public AudioClip gameOverSound; // Sound to play on game over
    //public AudioClip gameWonSound; // Sound to play on level completion
    public string nextLevel; // Name of the next level to load
    public Transform player; // Reference to the player object
    public float groundY = -10.0f; // Y position considered as 'ground' or 'out of bounds'

    private float _countDown;
    private bool _isGameOver;
    private int _score; // Keeps track of the score

    private void Start()
    {
        _countDown = levelDuration;
        _isGameOver = false;
        _score = 0;
        SetTimerText();
        scoreText.text = "Score: 0"; // Initialize score text
    }

    void Update()
    {
        if (!_isGameOver)
        {
            UpdateTimer();
            CheckPlayerOutOfBounds();
        }
    }
    
    void UpdateTimer()
    {
        if (_countDown > 0.0f)
        {
            _countDown -= Time.deltaTime;
            SetTimerText();
        }
        else if (_countDown <= 0.0f && !_isGameOver)
        {
            _countDown = 0.0f;
            LevelLost(); // If time runs out, player loses the level
        }
    }

    void CheckPlayerOutOfBounds()
    {
        if (player.position.y < groundY)
        {
            LevelLost();
        }
    }

    void SetTimerText()
    {
        levelTimer.text = $"Time: {_countDown:f2}";
    }
    
    // call this on collectable collision
    public void AddScore(int points)
    {
        _score += points;
        scoreText.text = $"Score: {_score}";
    }

    void LevelLost()
    {
        _isGameOver = true;
        //PlaySound(gameOverSound);  
        Invoke(nameof(LoadCurrentLevel), 2);
    }

    void LevelWon()
    {
        _isGameOver = true;
        //PlaySound(gameWonSound); 

        if (!string.IsNullOrEmpty(nextLevel))
            Invoke(nameof(LoadNextLevel), 2);
    }

    void LoadNextLevel()
    {
        // lwk this can be anything, not just the actual levels
        if (nextLevel.Equals("Level 4")) {
            return;
        }
        SceneManager.LoadScene(nextLevel);
    }

    void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main!.transform.position);
    }

    // Call this method to trigger level completion from other scripts (e.g., when all objectives are met)
    public void TriggerLevelWon()
    {
        if (!_isGameOver) LevelWon();
    }
    
    public void TriggerLevelLost()
    {
        if (!_isGameOver) LevelLost();
    }
}
