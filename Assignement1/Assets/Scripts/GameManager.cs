using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GroundTile[] groundTiles;

    [SerializeField]
    private Text scoreText;

    private float score = 0f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        groundTiles = FindObjectsOfType<GroundTile>();
        score = groundTiles.Length;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score + "";
    }

    public void AddScore(float greenBlockValue)
    {
        score = score - greenBlockValue;

        UpdateScore();
    }

}
