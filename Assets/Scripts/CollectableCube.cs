using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCube : MonoBehaviour
{
    bool isCollected;
    int index; // determine height


    void Start()
    {
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
}
