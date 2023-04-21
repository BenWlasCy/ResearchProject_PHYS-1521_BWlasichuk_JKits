using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxScript : MonoBehaviour
{
    [SerializeField]
    int boxNumber;

    [SerializeField]
    GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTextValue(string textValue)
    {
        if(!(string.IsNullOrEmpty(textValue))){
        Debug.Log(true);
        controller.GetComponent<VectorController>().LogVectorValue(textValue, boxNumber);
        }
    }
}
