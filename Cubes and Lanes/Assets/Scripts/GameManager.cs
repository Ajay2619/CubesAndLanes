using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;} // singleton instance
    public float timeToMoveHorizontally = 20f; 
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;
    private int score;
    private float time;
    private bool canMoveHorizontally = false;
    public static event Action EnemyCrossed;
    public bool CanMoveHorizontally { get => canMoveHorizontally; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        EnemyCrossed += AddScore;
        // Invokes a one time function to enable horizontal movement
        Invoke("MoveHorizontally", timeToMoveHorizontally);
    }

    void Update()
    {
        //Timer countdown on screen
        time += Time.deltaTime;
        timerText.text = $"TIME: {(int)time}";
    }   

    private void MoveHorizontally()
    {
        canMoveHorizontally = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        EnemyCrossed?.Invoke();
    }

    private void AddScore()
    {
        score++;
        scoreText.text = $"SCORE {score}";
    }

    void OnDisable()
    {
        EnemyCrossed -= AddScore;
    }
}
