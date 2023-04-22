using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile_Object : MonoBehaviour
{

    Vector3 savedPosition;
    float savedVelocity;
    [SerializeField]
    Vector3 initialPosition;

    [SerializeField]
    GameObject areaText;

    bool launched;

    Rigidbody m_Rigidbody;

    [SerializeField]
    Transform platform;

    // Start is called before the first frame update
    void Start()
    {
        launched = false;
        savedVelocity = 0;
        m_Rigidbody = GetComponent<Rigidbody>();
        areaText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset() // used to reset the ball after a collision
    {
        transform.SetParent(platform);
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;
        transform.position = initialPosition;
    }

    public void TestForce() // testing adding force
    {
        initialPosition = transform.position;
        launched = true;
        this.transform.parent = null;
        m_Rigidbody.AddForce(savedVelocity, 0, 0, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other) // if ball hits the ground, reset and grab the position it landed at
    {
        if(other.transform.tag == "Ground")
        {
            if(launched) //kinda spaghetti code
            {
            launched = false;
            savedPosition = new Vector3 (transform.position.x, 0, 0);
            Reset();
            Debug.Log(savedPosition);
            areaText.GetComponent<TMP_Text>().text = ("Distance: " + savedPosition.x);
            areaText.SetActive(true);
            }
            if(!launched)
            {
            transform.position = initialPosition;
            }
        }
    }

    public void ChangeVelocity(string changeValue) // change starting force
    {
        Debug.Log(changeValue);
        float value = float.Parse(changeValue);
        savedVelocity = value;
    }
}
