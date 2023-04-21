using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



/* TODO
-- Finish Magnitude


*/




public class VectorController : MonoBehaviour
{
    public float[] Vector1 = new float[2];
    public float[] Vector2 = new float[2];
    public float[] combinedVector = new float[2]; // All vectors

    public float mag1, mag2;

    [SerializeField]
    List<GameObject> textBoxes = new List<GameObject>(); // the input boxes for the 2d Vectors

    [SerializeField]
    GameObject totalVector, magnitudeMenu1, magnitudeMenu2, dotMenu, normalize1, normalize2; //menus 
    // totalVector -  the total vector when multiplying or adding, 
    // magnitudeMenus - Menus for calculating magnitudes. Will be displayed besides
    void Start()
    {
        for(int i = 0; i < Vector1.Length; i++)//Set all Vectors to Zero.
        {
            Vector1[i] = 0f;
            Vector2[i] = 0f;
            Debug.Log(i);
        }
        totalVector.SetActive(false); //Make sure the totalvector and others are off by default
        magnitudeMenu1.SetActive(false);
        magnitudeMenu2.SetActive(false);
        dotMenu.SetActive(false);
        normalize1.SetActive(false);
        normalize2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogVectorValue(string check, int i)// (TextBoxScript) Load value to change the value of the Vector.
    {
        
        float value = float.Parse(check);
        switch(i)
        {
            case 1:
            Vector1[0] = value;
            if(Vector1[1] != 0)
            {
                magnitudeMenu1.SetActive(true);
                float totalMag = Magnitude(Vector1[0], Vector1[1]);
                mag1 = totalMag;
                magnitudeMenu1.transform.GetChild(0).GetComponent<TMP_Text>().text = mag1.ToString();
                for(int j = 0; j < 2; j++)
                {
                    float actualValue = Normalize(Vector1[j], totalMag);
                    normalize1.transform.GetChild(j).GetComponent<TMP_Text>().text = actualValue.ToString();
                }
                normalize1.SetActive(true);
            }
            break;

            case 2:
            Vector1[1] = value;
            if(Vector1[0] != 0)
            {
                magnitudeMenu1.SetActive(true);
                float totalMag = Magnitude(Vector1[0], Vector1[1]);
                mag1 = totalMag;
                magnitudeMenu1.transform.GetChild(0).GetComponent<TMP_Text>().text = mag1.ToString();
                for(int j = 0; j < 2; j++)
                {
                    float actualValue = Normalize(Vector1[j], totalMag);
                    normalize1.transform.GetChild(j).GetComponent<TMP_Text>().text = actualValue.ToString();
                }
                normalize1.SetActive(true);
            }
            break;

            case 3:
            Vector2[0] = value;
            if(Vector2[1] != 0)
            {
                magnitudeMenu2.SetActive(true);
                float totalMag = Magnitude(Vector2[0], Vector2[1]);
                mag2 = totalMag;
                magnitudeMenu2.transform.GetChild(0).GetComponent<TMP_Text>().text = mag2.ToString();
                for(int j = 0; j < 2; j++)
                {
                    float actualValue = Normalize(Vector2[j], totalMag);
                    normalize2.transform.GetChild(j).GetComponent<TMP_Text>().text = actualValue.ToString();
                }
                normalize2.SetActive(true);
            }
            break;
            
            case 4:
            Vector2[1] = value;
            if(Vector2[0] != 0)
            {
                magnitudeMenu2.SetActive(true);
                float totalMag = Magnitude(Vector2[0], Vector2[1]);
                mag2 = totalMag;
                magnitudeMenu2.transform.GetChild(0).GetComponent<TMP_Text>().text = mag2.ToString();
                for(int j = 0; j < 2; j++)
                {
                    float actualValue = Normalize(Vector2[j], totalMag);
                    normalize2.transform.GetChild(j).GetComponent<TMP_Text>().text = actualValue.ToString();
                }
                normalize2.SetActive(true);
            }
            break;

            default:
            break;
        }
    }



    public void DotProduct()
    {
        
    }

    public float Magnitude(float X, float Y)
    {
        float result = Mathf.Sqrt((X * X) + (Y * Y));
        return result;
    }

    public float Normalize(float vector, float magnitude)
    {
        float normalizationThingy = (1 / magnitude);
        float actual = (vector * normalizationThingy);
        return actual;
    }



}
