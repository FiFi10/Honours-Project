using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class Detection : MonoBehaviour
{
    bool isHealthy = true;
    GameObject[] proximity;
    GameObject[] noOfHealthy;
    GameObject[] noOfInfected;
    float distance;
    

    void Start()
    {
        var number = Random.Range(1, 100);
        
        //Debug.Log(number);
        if(number <= 40)
        {
            this.GetComponent<Renderer>().material.color = Color.red;
            this.transform.tag = "Infected";
            isHealthy = false;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = Color.green;
            this.transform.tag = "Healthy";
        }
        StartCoroutine(SneezeCough());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.position);

        /*if (this.transform.tag == "Infected")
        {
            proximity = GameObject.FindGameObjectsWithTag("Healthy");
            foreach (GameObject person in proximity)
            {
                distance = Vector3.Distance(person.transform.position, this.transform.position);
                Debug.Log(distance);
            }
        }*/

        noOfHealthy = GameObject.FindGameObjectsWithTag("Healthy");
        noOfInfected = GameObject.FindGameObjectsWithTag("Infected");

        //Debug.Log("Healthy: " + noOfHealthy.Length + " / Infected: " + noOfInfected.Length);

        if (this.transform.position.x <= -19 && this.transform.position.z <= 1)
        {

            int hasLeft = PlayerPrefs.GetInt("left");
            hasLeft++;
            //Debug.Log(hasLeft);
            PlayerPrefs.SetInt("left", hasLeft);
            PlayerPrefs.Save();

            //GameObject gameState = GameObject.Find("GameState").GetComponent<Exit>();
            //gameState.left += 1;

            //GameObject gameState = GameObject.Find("GameState");
            //Exit exitScript = gameState.GetComponent<Exit>();
            //gameState.left += 1;

            Destroy(this);
            //Debug.Log("Left");
        }
    }

    IEnumerator SneezeCough()
    {
        yield return new WaitForSeconds(Random.Range(1,30));

        //proximity = GameObject.FindGameObjectsWithTag("Healthy");
        if (this.transform.position.x >= -19.5 && this.transform.position.z >= 3.01)
        {
            if (this.transform.tag == "Infected")
            {
                proximity = GameObject.FindGameObjectsWithTag("Healthy");

                foreach (GameObject person in proximity)
                {
                    distance = Vector3.Distance(person.transform.position, this.transform.position);
                    //Debug.Log(distance);

                    if (distance <= 2)
                    {
                        person.GetComponent<Renderer>().material.color = Color.red;
                        person.transform.tag = "Infected";
                    }
                }
            }
        }

        StartCoroutine(SneezeCough());
    }
}
