using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private FishSpawner _fishSpawner;
    [SerializeField] private BaseText _timeText;
    [SerializeField] private BaseText _scoreText;
    [SerializeField] private BaseText _highScoreText;
    [SerializeField] private BaseText _endScoreText;
    [SerializeField] private GameObject _gameEnvironment;
    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private Canvas _inGameCanvas;
    [SerializeField] private Canvas _gameOverCanvas;
    [SerializeField] private GameState _gameState;
    [SerializeField] private int _score;
    [SerializeField] private float _time = 100;
    [SerializeField] private float _defaultTime = 100;

    public GameState GameState => _gameState;
    public int Score { get => _score; set => _score = value; }
    public float Time { get => _time; set => _time = value; }

    public void ChangeGameState(GameState newState)
    {
        if (_gameState == newState) return;

        _gameState = newState;
        switch (_gameState)
        {
            case GameState.MainMenu:
                Debug.Log(PlayerPrefs.GetInt("HighScore", 0));
                _highScoreText.Text.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
                _mainMenuCanvas.gameObject.SetActive(true);
                _gameEnvironment.SetActive(false);
                break;
            case GameState.Pause:
                UnityEngine.Time.timeScale = 0;
                break;
            case GameState.InGame:
                UnityEngine.Time.timeScale = 1;
                _mainMenuCanvas.gameObject.SetActive(false);
                _gameEnvironment.SetActive(true);
                break;
            case GameState.GameOver:
                if (_score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", _score);
                }
                _endScoreText.Text.text = "SCORE: " + _score.ToString();
                _gameOverCanvas.gameObject.SetActive(true);
                _gameEnvironment.SetActive(false);
                _inGameCanvas.gameObject.SetActive(false);
                UnityEngine.Time.timeScale = 0;
                break;
            case GameState.Restart:
                UnityEngine.Time.timeScale = 1;
                _gameOverCanvas.gameObject.SetActive(false);
                _gameEnvironment.SetActive(true);
                _inGameCanvas.gameObject.SetActive(true);
                _time = _defaultTime;
                _score = 0;
                _fishSpawner.ReturnAllFishToPool();
                ChangeGameState(GameState.InGame);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Start()
    {
        _time = _defaultTime;
        Debug.Log(PlayerPrefs.GetInt("HighScore", 0));
        _highScoreText.Text.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        ChangeGameState(GameState.MainMenu);
    }

    private void Update()
    {
        if (_gameState == GameState.InGame)
        {
            _time -= UnityEngine.Time.deltaTime;
            _timeText.Text.text = "Time: " + Mathf.Round(_time).ToString();
            _scoreText.Text.text = "Score: " + _score.ToString();
            if (_time <= 0)
            {
                ChangeGameState(GameState.GameOver);
            }
        }
    }
}

[Serializable]
public enum GameState
{
    MainMenu,
    Pause,
    Restart,
    InGame,
    GameOver
}