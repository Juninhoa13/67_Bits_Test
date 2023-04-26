using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposito : MonoBehaviour
{

    public GameObject Aviso;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other) //Collision
    {
        if(other.gameObject.tag == "Player")
        {
            Aviso.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other) //Collision
    {
        if(other.gameObject.tag == "Player")
        {
            Aviso.SetActive(false);
        }
    }
}
