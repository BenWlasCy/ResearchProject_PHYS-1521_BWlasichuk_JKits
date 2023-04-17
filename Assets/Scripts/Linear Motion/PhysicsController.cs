using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{

    float worldGravity;
    // Start is called before the first frame update
    void Start()
    {
        worldGravity = -9.81f;
        Physics.gravity = new Vector3(0, worldGravity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGravity(string g)
    {
        Debug.Log(g);
        float value = float.Parse(g);
        worldGravity = value;
        Physics.gravity = new Vector3(0, -worldGravity, 0);
    }
}
