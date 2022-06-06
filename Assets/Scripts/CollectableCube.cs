using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCube : MonoBehaviour
{
    bool isCollected;
    int index; // determine height
    public GameObject collector;
    GameObject gameManager;
    GameObject player;

    void Start()
    {
        collector = GameObject.FindGameObjectWithTag("Collector");
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("PlayerCube");
        isCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollected ==true && transform.parent != null) 
        {
            transform.localPosition = new Vector3(0, -index, 0);
        }
        
    }

    public bool GetIsCollected() 
    {
        return isCollected;
    }

    public void SetIsCollected()
    {
        isCollected = true;
    }

    public void SetIndex(int index) 
    {
        this.index = index;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log(player.GetComponent<PlayerController>().GetPlayerHeight());
            if (player.GetComponent<PlayerController>().GetPlayerHeight() == 1) 
            {
                gameManager.GetComponent<GameManager>().FinishGame();
            }
            collector.GetComponent<Collector>().decreaseHeight();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
