using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    //string[] existing;
    GameObject[] noOfHealthy;
    GameObject[] noOfInfected;
    public int left;
    
    int simNo;
    void Start()
    {
        //PlayerPrefs.SetInt("simNo", 1);
        PlayerPrefs.SetInt("left", 0);
        this.transform.tag = "Exit";
        
        if(PlayerPrefs.GetInt("simNo") > 10)
        {
            PlayerPrefs.SetInt("simNo", 1);
        }
        
        simNo = PlayerPrefs.GetInt("simNo");
    }

    /*void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Healthy")
        {
            left++;
        }
        
        else if (col.gameObject.tag == "Infected")
        {
            left++;
        }
        
    }*/

    // Update is called once per frame
    void Update()
    {
        int left = PlayerPrefs.GetInt("left");
        //Debug.Log(left);
        Debug.Log(simNo + " healthy : " + GameObject.FindGameObjectsWithTag("Healthy").Length + " infected : " + GameObject.FindGameObjectsWithTag("Infected").Length);

        if (left >= 99)
        {
            int noOfHealthy = GameObject.FindGameObjectsWithTag("Healthy").Length;
            int noOfInfected = GameObject.FindGameObjectsWithTag("Infected").Length;

            string[] persons =
            {noOfHealthy.ToString(), noOfInfected.ToString()};

            //existing = File.ReadAllText("Results.txt");
            //Debug.Log(existing);
            
            File.AppendAllLines("Results.txt", persons);

            
            if(simNo <= 10)
            {
                simNo++;
                PlayerPrefs.SetInt("simNo", simNo);
                SceneManager.LoadScene(1);
            }
            else if(simNo > 10)
            {
                PlayerPrefs.SetInt("simNo", 1);
                UnityEditor.EditorApplication.isPlaying = false;
            }
            //UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
            
        }
    } 
}
