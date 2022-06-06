using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject collect;
    [SerializeField]
    GameObject obstacle;
    int x = -5;

    void Start()
    {
        for (int i = 0; i < 20; i++) 
        {
            int type = Random.Range(0,2);
            if (type == 0) 
            {
                GameObject collect_ = Instantiate(collect);
                collect_.transform.position = new Vector3(x,1,0);
                x -= 5;

            } 
            else 
            {
                GameObject obstacle_ = Instantiate(obstacle);
                obstacle_.transform.position = new Vector3(x,1,0);
                x -= 5;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
}
