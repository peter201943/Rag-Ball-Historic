using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    //This script creates the cubes that are called from the preferences menu, stores them, and assigns them a random color.

    public GameObject Cube;
    public GameObject Cube2;
    public GameObject ActualCube;
    public GameObject ActualSphere;
    public GameObject BALL;
    public GameObject RAG;
    public float minScale = .5f;
    public float maxScale = 1.5f;
    
    


    public void SpawnCube()
    {     
			GameObject cube = Instantiate(Cube, transform.position, Quaternion.identity);
        	cube.GetComponent<Rigidbody>().AddForce(Random.Range(100, 500), 0, Random.Range(100, 500));
        	cube.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
        	cube.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    void Update()
    {
        if (Input.GetKey("s"))
        {
                GameObject cube = Instantiate(Cube, transform.position, Quaternion.identity);
                cube.GetComponent<Rigidbody>().AddForce(Random.Range(100, 500), 0, Random.Range(100, 500));
                cube.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
                cube.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));            
        }

        if (Input.GetKey("a"))
        {
            GameObject cube = Instantiate(Cube2, transform.position, Quaternion.identity);
            cube.GetComponent<Rigidbody>().AddForce(Random.Range(100, 500), 0, Random.Range(100, 500));
            cube.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
            cube.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        if (Input.GetKey("d"))
        {
            GameObject cube = Instantiate(ActualCube, transform.position, Quaternion.identity);
            cube.GetComponent<Rigidbody>().AddForce(Random.Range(100, 500), 0, Random.Range(100, 500));
            cube.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
            cube.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        if (Input.GetKey("f"))
        {
            GameObject cube = Instantiate(ActualSphere, transform.position, Quaternion.identity);
            cube.GetComponent<Rigidbody>().AddForce(Random.Range(100, 500), 0, Random.Range(100, 500));
            cube.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
            cube.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        if (Input.GetKey("g"))
        {
            GameObject cube = Instantiate(BALL, transform.position, Quaternion.identity);
            cube.GetComponent<Rigidbody>().AddForce(Random.Range(100, 500), 0, Random.Range(100, 500));
            cube.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
            cube.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        if (Input.GetKey("h"))
        {
            GameObject cube = Instantiate(RAG, transform.position, Quaternion.identity);
            cube.GetComponent<Rigidbody>().AddForce(Random.Range(100, 500), 0, Random.Range(100, 500));
            cube.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
            cube.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
