using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particlesPrefab;
    
    public void CreateParticles()
    {
        Instantiate(particlesPrefab, transform.position, transform.rotation);
    }
}
