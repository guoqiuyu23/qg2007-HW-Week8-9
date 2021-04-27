using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLocker : MonoBehaviour
{
    public GameObject lockerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Destroy(this.gameObject);
        Instantiate<GameObject>(lockerPrefab);
        Debug.Log("click locker");
    }
}
