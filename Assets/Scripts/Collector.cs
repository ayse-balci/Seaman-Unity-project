using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    GameObject playerCube;
    int height = 0;

    void Start()
    {
        playerCube = GameObject.Find("PlayerCube");
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
            playerCube.GetComponent<PlayerController>().UpdateScore();
        }
    }

    public void decreaseHeight()
    {
        height--;
    }
}
