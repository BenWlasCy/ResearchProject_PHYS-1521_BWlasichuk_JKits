using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



/* TODO


*/




public class VectorController : MonoBehaviour
{
    public float[] Vector1 = new float[2];
    public float[] Vector2 = new float[2];
    public float[] combinedVector = new float[2]; // All vectors

    public float mag1, mag2, scalar;

    [SerializeField]
    List<GameObject> textBoxes = new List<GameObject>(); // the input boxes for the 2d Vectors

    [SerializeField]
    GameObject totalVector, magnitudeMenu1, magnitudeMenu2, altMenu, normalize1, normalize2; //menus 

    [SerializeField]
    GameObject vector1Scalar1, vector1Scalar2, vector2Scalar1, vector2Scalar2;
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
        altMenu.SetActive(false);
        normalize1.SetActive(false);
        normalize2.SetActive(false);
        vector2Scalar1.SetActive(false);
        vector2Scalar2.SetActive(false);
        vector1Scalar1.SetActive(false);
        vector1Scalar2.SetActive(false);

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
                    if(scalar != 0)
                    {
                        float scalarValue1 = (Vector1[j] * scalar);
                        float scalarValue2 = (scalar * Vector1[j]);
                        vector1Scalar1.transform.GetChild(j).GetComponent<TMP_Text>().text = scalarValue1.ToString();
                        vector1Scalar2.transform.GetChild(j).GetComponent<TMP_Text>().text = scalarValue2.ToString();
                        vector1Scalar1.SetActive(true);
                        vector1Scalar2.SetActive(true);
                    }
                    
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
                    if(scalar != 0)
                    {
                        float scalarValue1 = (Vector1[j] * scalar);
                        float scalarValue2 = (scalar * Vector1[j]);
                        vector1Scalar1.transform.GetChild(j).GetComponent<TMP_Text>().text = scalarValue1.ToString();
                        vector1Scalar2.transform.GetChild(j).GetComponent<TMP_Text>().text = scalarValue2.ToString();
                        vector1Scalar1.SetActive(true);
                        vector1Scalar2.SetActive(true);
                    }
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
                    if(scalar != 0)
                    {
                        Debug.Log("HAHA");
                        float scalarValue1 = (Vector2[j] * scalar);
                        float scalarValue2 = (scalar * Vector2[j]);
                        vector2Scalar1.transform.GetChild(j).GetComponent<TMP_Text>().text = scalarValue1.ToString();
                        vector2Scalar2.transform.GetChild(j).GetComponent<TMP_Text>().text = scalarValue2.ToString();
                        vector2Scalar1.SetActive(true);
                        vector2Scalar2.SetActive(true);
                    }
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
                    if(scalar != 0)
                    {
                        Debug.Log("HAHA");
                        float scalarValue1 = (Vector2[j] * scalar);
                        float scalarValue2 = (scalar * Vector2[j]);
                        vector2Scalar1.transform.GetChild(j).GetComponent<TMP_Text>().text = scalarValue1.ToString();
                        vector2Scalar2.transform.GetChild(j).GetComponent<TMP_Text>().text = scalarValue2.ToString();
                        vector2Scalar1.SetActive(true);
                        vector2Scalar2.SetActive(true);
                    }
                }
                normalize2.SetActive(true);
            }
            break;

            default:
            break;
        }
    }



    public void ActivateDotProduct()// Activates if all input fields are not null
    {
        bool checkZero = true;
        for(int i = 0; i < Vector1.Length; i++)//Set all Vectors to Zero.
        {
            if(Vector1[i] == 0 || Vector2[i] == 0)
            {
                checkZero = false;
                break;
            }
        }
        if(checkZero)
        {
            float result = DotProduct(Vector1[0], Vector1[1], Vector2[0], Vector2[1]);
            ChangeAltMenu(result, "Dot Product");
        }
    }

    public float DotProduct(float vector1x, float vector1y, float vector2x, float vector2y)
    {
        float result = Mathf.Sqrt((vector1x * vector2x) + (vector1y * vector2y));
        return result;
    }

    public void VectorAngleActivate()// Activates if all input fields are not null
    {
        Debug.Log("One in a krillion");
        bool checkZero = true;
        for(int i = 0; i < Vector1.Length; i++)//Set all Vectors to Zero.
        {
            if(Vector1[i] == 0 || Vector2[i] == 0)
            {
                checkZero = false;
                break;
            }
        }
        if(checkZero)
        {
            float result = VectorAngle(Vector1[0], Vector1[1], Vector2[0], Vector2[1]);
            Debug.Log(result);
            ChangeAltMenu(result, "Angle");
        }
    }

    public float VectorAngle(float vector1x, float vector1y, float vector2x, float vector2y) // TODO: Mathf.Acos doesn't work for some reason
    {
        float result = Mathf.Rad2Deg * (Mathf.Acos(DotProduct(vector1x, vector1y, vector2x, vector2y) / (mag1 * mag2)));
        return result;
    }

    public void ChangeAltMenu(float value, string titleText) // used to easily change alt menu between dotproduct and anglebetweenvectors
    {
        altMenu.transform.GetChild(1).GetComponent<TMP_Text>().text = value.ToString();
        altMenu.transform.GetChild(0).GetComponent<TMP_Text>().text = titleText;
        altMenu.SetActive(true);
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


    //maths

    public void DoMath(string mathType)
    {

        bool checkZero = true;
        for(int i = 0; i < Vector1.Length; i++)//Set all Vectors to Zero.
        {
            if(Vector1[i] == 0 || Vector2[i] == 0)
            {
                checkZero = false;
                break;
            }
        }
        if(checkZero)
        {
            switch(mathType)
            {
            
                case "add":
                combinedVector[0] = (Vector1[0] + Vector2[0]);
                combinedVector[1] = (Vector1[1] + Vector2[1]);
                break;

                case "subtract":
                combinedVector[0] = (Vector1[0] - Vector2[0]);
                combinedVector[1] = (Vector1[1] - Vector2[1]);
                break;

                default:
                break;

            }

            ChangeNewMenu(combinedVector[0], combinedVector[1]);


        }
    }


    public void ChangeNewMenu(float newX, float newY)
    {
        totalVector.transform.GetChild(0).GetComponent<TMP_Text>().text = newX.ToString();
        totalVector.transform.GetChild(1).GetComponent<TMP_Text>().text = newY.ToString();
        totalVector.SetActive(true);
    }

    public void ChangeScalar(string value)
    {
        float number;
        bool success = float.TryParse(value, out number);
        if(success)
        {
            scalar = float.Parse(value);
        }
    }



}
