using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public Gradient g;

    public float mass;

    public float density;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        density = mass / 15;
        GetComponent<MeshRenderer>().material.color = g.Evaluate(density);
    }
}
