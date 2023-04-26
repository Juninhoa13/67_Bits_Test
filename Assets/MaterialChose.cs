using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChose : MonoBehaviour
{
    public Material[] material;
    public Renderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}