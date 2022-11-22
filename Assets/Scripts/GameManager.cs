using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public delegate void GameEvent();
    public static event GameEvent GameStart, GameOver, GameStateChange;

    private static GameManager _instance;
    private static InputManager _inputManager;

    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
            {
                Debug.LogError("GameManager is NULL");
            }
            return _instance;
        }
    }

    public static InputManager InputManager
    {
        get
        {
            if (_inputManager is null)
            {
                Debug.LogError("InputManager is NULL");
            }
            return _inputManager;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _instance = this;
        _inputManager = GetComponent<InputManager>();
    }

    private void Start()
    {
        GameStart?.Invoke();
    }
}