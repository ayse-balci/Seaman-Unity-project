using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private GameObject playerCube;
    void Awake()
	{
        playerCube = GameObject.Find("PlayerCube");

        scoreText.text = playerCube.GetComponent<PlayerController>().GetScore().ToString();
    }

    void Update()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = playerCube.GetComponent<PlayerController>().GetScore().ToString();
    }

}