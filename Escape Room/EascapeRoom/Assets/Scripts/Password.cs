using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password : MonoBehaviour
{
    public static Queue<string> passwordQueue = new Queue<string>();
    string checkpw;
    private string clearpw = null;
    public static bool fixLockerBug = false;
    public static bool getKey = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateLockerPassword(int password)
    {
        switch (password)
        {
            case 0:
                checkpassword();
                break;
            case 10:
                clearpassword();
                break;
            case 11:
                Destroy(this.gameObject);
                Debug.Log("close PW window");
                checkpw = null;
                passwordQueue.Clear();
                fixLockerBug = true;
                break;
            case 1:
                passwordQueue.Enqueue("1");
                break;
            case 2:
                passwordQueue.Enqueue("2");
                break;
            case 3:
                passwordQueue.Enqueue("3");
                break;
            case 4:
                passwordQueue.Enqueue("4");
                break;
            case 5:
                passwordQueue.Enqueue("5");
                break;
            case 6:
                passwordQueue.Enqueue("6");
                break;
            case 7:
                passwordQueue.Enqueue("7");
                break;
            case 8:
                passwordQueue.Enqueue("8");
                break;
            case 9:
                passwordQueue.Enqueue("9");
                break;
            default:
                break;
        }
    }

    public void checkpassword()
    {
        while (passwordQueue.Count > 0)
        {
            checkpw += passwordQueue.Dequeue();
        }

        Debug.Log("enter"+checkpw);
        if (checkpw == "141633")
        {
            GameManager.haveKey = true;
            getKey = true;
            Debug.Log("got key");
            Destroy(this.gameObject);
            fixLockerBug = true;
        }
        else
        {
            Debug.Log("wrong password");
        }
        checkpw = null;
        passwordQueue.Clear();
    }

    public void clearpassword()
    {
       
        checkpw = null;
        passwordQueue.Clear();
        Debug.Log("clear"+checkpw);
    }
}
