using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public PlatformEffector2D platform;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var downWards = Input.GetAxis("Vertical");
        if(downWards >= 0)
        {
            waitTime = 0.01f;
            platform.rotationalOffset = 0;
        }
        
        else if (downWards == -1)
        {
            if (waitTime <= 0)
            {
                platform.rotationalOffset = 180;
                waitTime = 0.01f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
