using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    public static event Action<IState> OnGameStateChanged;

    private static GameStateMachine _instance;
    
    private StateMachine _stateMachine;
    public Type CurrentStateType => _stateMachine.CurrentState.GetType();

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed GameStateMachine On Awake");
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
        
        _stateMachine = new StateMachine();
        _stateMachine.OnStateChanged += state => OnGameStateChanged?.Invoke(state);

        var menu = new Menu();
        var loading = new LoadLevel();
        var play = new Play();
        var pause = new Pause();
        
        _stateMachine.SetState(menu);
        
        _stateMachine.AddTransition(menu, loading, () => PlayButton.LevelToLoad != null);
        _stateMachine.AddTransition(loading, play, loading.Finished);
        _stateMachine.AddTransition(play, pause, () => PlayerInput.Instance.PausePressed);
        _stateMachine.AddTransition(pause, play, () => PlayerInput.Instance.PausePressed);
        _stateMachine.AddTransition(pause, menu, () => RestartButton.Pressed);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }

    private void OnDestroy()
    {
        _stateMachine?.SetState(null);
        Debug.Log("Destroyed GameStateMachine");
    }
}

public class Menu : IState
{
    public void Tick()
    {
    }

    public void OnEnter()
    {
        PlayButton.LevelToLoad = null;
        SceneManager.LoadSceneAsync("Menu");
    }

    public void OnExit()
    {
    }
}

public class Play : IState
{
    public void Tick()
    {
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }
}

public class LoadLevel : IState
{
    public bool Finished() => _operations.TrueForAll(t => t.isDone);
    
    private List<AsyncOperation> _operations = new List<AsyncOperation>();
    
    public void Tick()
    {
    }

    public void OnEnter()
    {
        _operations.Add(SceneManager.LoadSceneAsync(PlayButton.LevelToLoad));
        _operations.Add(SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive));
    }

    public void OnExit()
    {
        _operations.Clear();
    }
}

public class Pause : IState
{
    public static bool Active { get; private set; }
    
    public void Tick()
    {
    }

    public void OnEnter()
    {
        Active = true;
        Time.timeScale = 0f;
    }

    public void OnExit()
    {
        Active = false;
        Time.timeScale = 1f;
    }
}