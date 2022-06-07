using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveForwardSpeed;
    [SerializeField]
    private float xAxisSpeed;
    private float speed = 0;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal") * xAxisSpeed * Time.deltaTime;
        this.transform.Translate(xAxis, 0, speed * Time.deltaTime);
    }

    public void UpdateScore()
    {
        score += 10;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetPlayerHeight()
    {
        return ((int)transform.position.y);
    }

    public void SetSpeed()
    {
        speed = moveForwardSpeed;
    }

    public void FinishGame() 
    {
        this.speed = 0;
        this.xAxisSpeed = 0;
    }
}
