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
        Vector3 lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)); // Get the lower left corner of the screen
        float bgMaxX = backgrounds[0].GetComponent<Transform>().position.x + backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x / 2; // Get the rightmost x position of the background

        if (lowerLeft.x > bgMaxX)
        {
            GameObject leftBG = backgrounds[0];
            Vector3 temp = new Vector3(2 * leftBG.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);
            leftBG.GetComponent<Transform>().position += temp;

            backgrounds.RemoveAt(0);
            backgrounds.Add(leftBG);
        }

    }
}
