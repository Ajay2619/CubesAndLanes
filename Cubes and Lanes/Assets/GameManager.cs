using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    [SerializeField] private TMP_Text scoreText;
    public static event Action EnemyCrossed;

    void Start()
    {
        EnemyCrossed += AddScore;
    }

    void OnTriggerEnter(Collider collider)
    {
        EnemyCrossed?.Invoke();
    }

    void AddScore()
    {
        score++;
        scoreText.text = $"SCORE {score}";
    }

    void OnDisable()
    {
        EnemyCrossed -= AddScore;
    }
}
