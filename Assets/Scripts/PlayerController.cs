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
    private float xSpeed = 0;
    
    public int score = 0;
    private float xRange = (float) 4.7;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
        this.transform.Translate(xAxis, 2 , speed * Time.deltaTime);


        if (transform.position.z < -xRange) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -xRange);
        } 
        if ( transform.position.z > xRange) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, xRange);

        }
        
        
    }

    public void UpdateScore()
    {
        score += 10;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScoreZero()
    {
        score = 0;
    }

    public int GetPlayerHeight()
    {
        return ((int)transform.position.y);
    }

    public void SetSpeed()
    {
        this.speed = moveForwardSpeed;
        this.xSpeed = xAxisSpeed;
    }

    public void FinishGame() 
    {
        this.speed = 0;
        this.xSpeed = 0;
    }
}
