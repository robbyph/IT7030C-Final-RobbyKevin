using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{

    Vector3 startPos = new Vector3(0, 0, 0);
    Vector3 targetPos = new Vector3(0, 0, 0);

    Vector3 mobScale;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        // targetPos = startPos + new Vector3(2.0f, 0, 0);
        mobScale = transform.localScale;
        if (mobScale.x < 0)
        {
            targetPos = startPos + new Vector3(-2.0f, 0, 0);
        }
        else
        {
            targetPos = startPos + new Vector3(2.0f, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (pos != targetPos)
        {
            transform.position = Vector3.MoveTowards(pos, targetPos, 0.002f);
        }
        else
        {
            // This is where the flipping should occur, when the mob reaches its "destination"
            
            if (pos == targetPos)
            {
                mobScale.x *= -1;
                transform.localScale = mobScale;
            }

            targetPos = startPos;
            if (pos == startPos)
            {
                if (mobScale.x < 0)
                {
                    targetPos = startPos + new Vector3(-2.0f, 0, 0);
                }
                else
                {
                    targetPos = startPos + new Vector3(2.0f, 0, 0);
                }
                
            }
        }
    }
}