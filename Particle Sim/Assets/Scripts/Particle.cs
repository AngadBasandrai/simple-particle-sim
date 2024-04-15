using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float mass;
    [HideInInspector]
    public Rigidbody rb;
    public Vector3 forceOnThis;

    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<Rigidbody>())
        {
            gameObject.AddComponent<Rigidbody>();
        }
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.mass = mass;
    }

    // Update is called once per frame
    public void Gravitate()
    {
        forceOnThis = Vector3.zero;
        foreach (Particle particle in ParticleSpawner.Spawns)
        {
            Vector3 direction = rb.position - particle.rb.position;
            float distance = direction.magnitude;
            float forceMag = (UniversalConstant.G * rb.mass * particle.rb.mass) / Mathf.Pow(distance, 2);
            Vector3 force = direction.normalized * forceMag;

            if (particle == this)
            {
                return;
            }
            forceOnThis -= force;
        }
    }

    public void ApplyForce()
    {
        rb.AddForce(forceOnThis);
    }

    public void Update()
    {
        try
        {
            CellSpawner.instance.cells[(int)rb.position.x + CellSpawner.instance.bounds][(int)rb.position.z + CellSpawner.instance.bounds].mass += 1;
        }
        catch{}
    }
}