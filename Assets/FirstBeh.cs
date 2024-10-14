using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBeh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("hello!");
        //create a game object
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "a cube";
        //setting position
        cube.transform.position = new Vector3(0, Random.Range(0, 5), 0);
        //play as this gameobject sub-object
        cube.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("This Update!");
    }
    void OnEnable()
    {
        Debug.Log("This Enabled!");
    }

    void OnDisable()
    {
        Debug.Log("This Disabled!");
    }
}
