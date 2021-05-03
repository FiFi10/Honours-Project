using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int simNo = PlayerPrefs.GetInt("simNo");
        if (simNo <= 10)
        {
            SceneManager.LoadScene(0);
        }
        else if(simNo > 10)
        {
            PlayerPrefs.SetInt("simNo", 1);
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

