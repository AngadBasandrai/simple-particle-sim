using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public static ParticleSpawner Instance;
    public static Particle[] Spawns;
    public GameObject[] particles;
    public GameObject particle;
    public bool spawn = false;
    public int spawns;
    public int xOff;
    public int yOff;
    public int zOff;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance)
        {
            Destroy(Instance);
        }    
        Instance = this;

        if (spawn)
        {
            for (int i = 0; i < spawns; i++)
            {
                GameObject g;
                g = Instantiate(particle, transform);
                g.transform.position = new Vector3(Random.Range(-(175f / Mathf.Pow(10f, 4f)), (175f / Mathf.Pow(10f, 2f))) + xOff, yOff, Random.Range(-(175f / Mathf.Pow(10f, 2f)), (175f / Mathf.Pow(10f, 2f))) + zOff);
            }
        }
        Spawns = FindObjectsOfType<Particle>();
    }

    void Update()
    {
        foreach (Particle particle in Spawns)
        {
            particle.Gravitate();
        }
    }

    void LateUpdate()
    {
        foreach (Particle particle in Spawns)
        {
            particle.ApplyForce();
        }
    }
}
