using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject collect;
    [SerializeField]
    GameObject obstacle;
    [SerializeField]
    GameObject leftHalfObstacle;
    [SerializeField]
    GameObject rightHalfObstacle;
    [SerializeField]
    GameObject doubleObstacle;
    [SerializeField]
    GameObject award;
    [SerializeField]
    GameObject threeAward;
    int x = -5;
    GameObject player;
    [SerializeField]
    GameObject startPanel;
    [SerializeField]
    GameObject scorePanel;
    [SerializeField]
    GameObject finishPanel;
    List<GameObject> obstacleList;
    List<GameObject> awardList;

    void Start()
    {
        player = GameObject.Find("PlayerCube");
        startPanel.SetActive(true);
        obstacleList = new List<GameObject> {obstacle, leftHalfObstacle, rightHalfObstacle, doubleObstacle};
        awardList = new List<GameObject> {award, threeAward};

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    public void StartGame()
    {
        startPanel.SetActive(false);
        scorePanel.SetActive(true);
        player.GetComponent<PlayerController>().SetSpeed();
        createCollectsAndObstacles();
    }

    void createCollectsAndObstacles()
    {
        for (int i = 0; i < 50; i++) 
        {
            int type = Random.Range(0,4);
            if (type == 0 && i!= 0 && i!= 1) 
            {
                
                int obstacleType = Random.Range(0,4);
                GameObject obstacle_ = Instantiate(obstacleList[obstacleType]);
                if (obstacleType == 1) 
                {
                    obstacle_.transform.position = new Vector3(x,1, (float) -2.5);   // left obstacle pos
                } 
                else if (obstacleType == 2) 
                {
                    obstacle_.transform.position = new Vector3(x,1, (float) 2.5); // right obstacle pos
                }
                else{
                    obstacle_.transform.position = new Vector3(x,1, 0);
                }
                
                x -= 5;
            }
            else if (type == 1) 
            {
                int awardType = Random.Range(0,2);
                GameObject award = Instantiate(awardList[awardType]);
                award.transform.position = new Vector3(x,1, 0);
                x -= 5;
            }
            else 
            {
                GameObject collect_ = Instantiate(collect);
                float z = Random.Range(-4, 4);
                collect_.transform.position = new Vector3(x,1,z);
                x -= 5;
            }
        }
    }

    public void FinishGame()
    {
        player.GetComponent<PlayerController>().FinishGame();
        finishPanel.SetActive(true);
        Debug.Log("game finished");
    }
}
