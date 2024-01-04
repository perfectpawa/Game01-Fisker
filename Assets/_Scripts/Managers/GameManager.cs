using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private int _score;
    [SerializeField] private int _time;

    public GameState GameState => _gameState;
    public int Score { get => _score; set => _score = value; }
    public int Time { get => _time; set => _time = value; }

    public void ChangeGameState(GameState newState)
    {
        if(_gameState == newState) return;

        _gameState = newState;
        switch (_gameState)
        {
            case GameState.MainMenu:
                break;
            case GameState.Pause:
                break;
            case GameState.InGame:
                break;
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

[Serializable]
public enum GameState
{
    MainMenu,
    Pause,
    InGame,
    GameOver
}