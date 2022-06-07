using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCube : MonoBehaviour
{
    bool isCollected;
    int index; // determine height
    public GameObject collector;
    GameObject player;
    GameObject gameManager;

    void Start()
    {
        collector = GameObject.FindGameObjectWithTag("Collector");
        player = GameObject.Find("PlayerCube");
        gameManager = GameObject.Find("GameManager");
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
            collector.GetComponent<Collector>().decreaseHeight();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.gameObject.tag == "FinishCube")
        {
            gameManager.GetComponent<GameManager>().FinishGame();
        }
    }
}
