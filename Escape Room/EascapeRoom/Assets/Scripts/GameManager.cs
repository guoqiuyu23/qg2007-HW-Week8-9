using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public LocationScriptableObject currentLocation;
    // public Text locationNameText;
    public GameObject currentBackground;
    public GameObject currentFurniture1;
    public GameObject currentFurniture2;
    public Text locationDescription;
    public GameObject buttonDown;
    public GameObject buttonUp;
    public GameObject buttonLeft;
    public GameObject buttonRight;
    public Texture2D tex;
    public static bool haveKey = false;
    public GameObject doorKey;
    
    // Start is called before the first frame update
    void Start()
    { 
        UpdateLocation();
        Debug.Log("start");
        
        
    }

    private void Update()
    {
        if (Password.fixLockerBug == true)
        {
            currentFurniture1 = Instantiate<GameObject>(currentLocation.furniture1);
            Password.fixLockerBug = false;
        }

        if (Password.getKey == true)
        {
            Instantiate<GameObject>(doorKey);
            Password.getKey = false;
        }
    }

    public void MoveDirection(int dir)
    {
        switch (dir)
        {
            case 0:
                currentLocation = currentLocation.locationUp;
                break;
            case 1:
                currentLocation = currentLocation.locationDown;
                break;
            case 2:
                currentLocation = currentLocation.locationRight;
                break;
            case 3:
                currentLocation = currentLocation.locationLeft;
                break;
            default:
                break;
        }
        
        UpdateLocation();
    }

    public void UpdateLocation()
    {
        Debug.Log("key?"+haveKey);
       // locationNameText.text = currentLocation.locationName;
        locationDescription.text = currentLocation.description;
        Destroy(currentBackground);
        Destroy(currentFurniture1);
        Destroy(currentFurniture2);
        currentBackground = Instantiate<GameObject>(currentLocation.background);
        currentFurniture1 = Instantiate<GameObject>(currentLocation.furniture1);
        currentFurniture2 = Instantiate<GameObject>(currentLocation.furniture2);
        
        
        if (currentLocation.locationRight == null)
        {
            buttonRight.SetActive(false);
        }
        else
        {
            currentLocation.locationRight.locationLeft = currentLocation;
            buttonRight.SetActive(true);
        }

        if (currentLocation.locationUp == null)
        {
            buttonUp.SetActive(false);
            Debug.Log("up false");
        }
        else
        {
            currentLocation.locationUp.locationDown = currentLocation;
            buttonUp.SetActive(true);
        }

        if (currentLocation.locationDown == null)
        {
            buttonDown.SetActive(false);
        }
        else
        {
            currentLocation.locationDown.locationUp = currentLocation;
            buttonDown.SetActive(true);
        }

        if (currentLocation.locationLeft == null)
        {
            buttonLeft.SetActive(false);
        }
        else
        {
            currentLocation.locationLeft.locationRight = currentLocation;
            buttonLeft.SetActive(true);
        }
    }
    
   
    

}
