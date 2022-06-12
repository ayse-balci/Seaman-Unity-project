using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text levelText;
    private GameObject playerCube;
    GameObject gameManager;
    
    void Awake()
	{
        playerCube = GameObject.Find("PlayerCube");
        gameManager = GameObject.Find("GameManager");
        scoreText.text = playerCube.GetComponent<PlayerController>().GetScore().ToString();
        levelText.text = gameManager.GetComponent<GameManager>().GetLevel().ToString();
    }

    void LateUpdate()
    {
        UpdateTexts();
    }

    public void UpdateTexts()
    {
        scoreText.text = playerCube.GetComponent<PlayerController>().GetScore().ToString();
        levelText.text = gameManager.GetComponent<GameManager>().GetLevel().ToString();
    }

}