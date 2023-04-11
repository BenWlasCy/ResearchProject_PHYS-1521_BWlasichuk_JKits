using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class HeightPlatform : MonoBehaviour
{

    public float height;

    // Start is called before the first frame update
    void Start()
    {
        ChangeHeight(height.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When the input field text is entered, then the height of the object will be changed. Using string because I forgot how to get a float value from an input field
    public void ChangeHeight(string stringValue)
    {
        Debug.Log(stringValue);
        float value = float.Parse(stringValue);
        height = value;
        transform.position = new Vector3(-5f, height, 0f);
    }
}
