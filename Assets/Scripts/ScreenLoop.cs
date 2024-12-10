using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    public List<GameObject> backgrounds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 lowerRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));

        // Get the boundaries of the first and last background
        float leftBGMinX = backgrounds[0].GetComponent<Transform>().position.x - backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float rightBGMaxX = backgrounds[backgrounds.Count - 1].GetComponent<Transform>().position.x + backgrounds[backgrounds.Count - 1].GetComponent<SpriteRenderer>().bounds.size.x / 2;

        // Check if moving right
        if (lowerLeft.x > leftBGMinX)
        {
            GameObject leftBG = backgrounds[0];
            Vector3 temp = new Vector3(2 * leftBG.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);
            leftBG.GetComponent<Transform>().position += temp;
            backgrounds.RemoveAt(0);
            backgrounds.Add(leftBG);
        }

        // Check if moving left
        if (lowerRight.x < rightBGMaxX)
        {
            GameObject rightBG = backgrounds[backgrounds.Count - 1];
            Vector3 temp = new Vector3(-2 * rightBG.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);
            rightBG.GetComponent<Transform>().position += temp;
            backgrounds.RemoveAt(backgrounds.Count - 1);
            backgrounds.Insert(0, rightBG);
        }
    }
}
