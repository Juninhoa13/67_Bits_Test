using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empilhamento : MonoBehaviour
{
    public GameObject Empilhament1;
    public GameObject Empilhament2;
    public GameObject Empilhament3;
    public GameObject Empilhament4;
    public GameObject Empilhament5;

    public int Level = 2;

    PlayerController Soco;

    public MaterialChose materialchose;
    // Start is called before the first frame update
    void Start()
    {
        Empilhament1.SetActive(false);
        Empilhament2.SetActive(false);
        Empilhament3.SetActive(false);
        Empilhament4.SetActive(false);
        Empilhament5.SetActive(false);

        Soco = GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Soco.Item == 1)
        {
            Empilhament1.SetActive(true);
        }
        if(Soco.Item == 2)
        {
            Empilhament2.SetActive(true);
        }
        if(Soco.Item == 3 && Level == 3)
        {
            Empilhament3.SetActive(true);
        }
        if(Soco.Item == 4 && Level == 4)
        {
            Empilhament4.SetActive(true);
        }
        if(Soco.Item == 5 && Level == 5)
        {
            Empilhament5.SetActive(true);

        }
        if(Level == 3)
        {
            
            materialchose.rend.sharedMaterial = materialchose.material[1];
        }
        if(Level == 4)
        {
            
            materialchose.rend.sharedMaterial = materialchose.material[2];
        }
        if(Level == 5)
        {
            
            materialchose.rend.sharedMaterial = materialchose.material[3];

        }
    }
}
