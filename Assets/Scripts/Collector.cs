using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    GameObject playerCube;
    GameObject gameManager;
    public int height = 0;
    AudioSource audio;
    public AudioClip collectSound;
    public AudioClip hitSound;
    public AudioClip awardSound;
    void Start()
    {
        playerCube = GameObject.Find("PlayerCube");
        gameManager = GameObject.Find("GameManager");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playerCube.transform.position = new Vector3(transform.position.x, height+ 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect" && !other.gameObject.GetComponent<CollectableCube>().GetIsCollected() )
        {
            height += 1;
            other.gameObject.GetComponent<CollectableCube>().SetIsCollected();
            other.gameObject.GetComponent<CollectableCube>().SetIndex(height);
            other.gameObject.transform.parent = playerCube.transform;
            CollectSound();
        }
        else if (other.gameObject.tag == "Award")
        {
            playerCube.GetComponent<PlayerController>().UpdateScore();
            other.gameObject.SetActive(false);
            AwardSound();
        }

        else if (other.gameObject.tag == "Obstacle" &&  height != 0)
        {
            decreaseHeight(1);
            HitObstacleSound();
        }

        else if (other.gameObject.tag == "Obstacle" &&  height == 0)
        {
           HitObstacleSound();
           gameManager.GetComponent<GameManager>().SetIsWin(false);
           gameManager.GetComponent<GameManager>().FinishGame();
        }

        else if (other.gameObject.tag == "doubleObstacle" &&  height <= 1)
        {
            HitObstacleSound();
            gameManager.GetComponent<GameManager>().SetIsWin(false);
            gameManager.GetComponent<GameManager>().FinishGame();
        }

        else if (other.gameObject.tag == "doubleObstacle" && height > 1)
        {
            decreaseHeight(2);
            HitObstacleSound();
        }
        
        else if (other.gameObject.tag == "FinishCube")
        {
            gameManager.GetComponent<GameManager>().SetIsWin(true);
            gameManager.GetComponent<GameManager>().FinishGame();
        }
     }

    public void decreaseHeight(int h)
    {
        height-= h;
    }

    public int GetHeight()
    {
        return height;
    }

    public void SetHeight()
    {
        this.height = 0;
    }

    public void CollectSound()
    {
        audio.clip = collectSound;
        audio.Play();
    }

    public void HitObstacleSound()
    {
        audio.clip = hitSound;
        audio.Play();
    }

    public void AwardSound()
    {
        audio.clip = awardSound;
        audio.Play();
    }
    

}
