using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDrag()
    {
        transform.position = GetMousePosition();
        // transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
    
    Vector3 GetMousePosition()
    {
        //get the screen position of the mouse
        Vector3 mousePosition = Input.mousePosition;

        //set the z of the mouse based on the world positon of the gameObject
        mousePosition.z = 
            Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //return the transformed ScreenToWorldPoint of the mouse, based on the gameObjects z
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enter 2d");
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
