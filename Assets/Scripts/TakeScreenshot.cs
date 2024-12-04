using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    public string fName = "Background.png";
    public string fPath = "Assets/Screenshot";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CaptureScreen();
        }
    }

    void CaptureScreen()
    {
        System.IO.Directory.CreateDirectory(fPath);
        string fullPath = System.IO.Path.Combine(fPath, fName);
        ScreenCapture.CaptureScreenshot(fName);
        Debug.Log($"Screenshot saved to: {fullPath}");
    }
}
