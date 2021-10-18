using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //user presses enter, move to first loop
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
