using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Loja : MonoBehaviour
{
    public GameObject Aviso;
    public GameObject UpgradePanel;

    public GameObject UpgradeButton1;
    public GameObject UpgradeButton2;
    public GameObject UpgradeButton3;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button VoltarButton;

    public Empilhamento empilhamento;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(empilhamento.Level == 2)
        {
            UpgradeButton1.SetActive(true);
        }
        if(empilhamento.Level == 3)
        {
            UpgradeButton1.SetActive(false);
            UpgradeButton2.SetActive(true);
        }
        if(empilhamento.Level == 4)
        {
            UpgradeButton1.SetActive(false);
            UpgradeButton2.SetActive(false);
            UpgradeButton3.SetActive(true);
        }
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

    public void Upgrade1()
    {
        if(player.Moedas >= 30 && empilhamento.Level == 2)
        {
            player.Moedas -= 30;
            empilhamento.Level = 3;
            Button2.Select();
        }
        
    }

    public void Upgrade2()
    {
        if(player.Moedas >= 50 && empilhamento.Level == 3)
        {
            player.Moedas -= 50;
            empilhamento.Level = 4;
            Button3.Select();
        }
    }

    public void Upgrade3()
    {
        if(player.Moedas >= 80 && empilhamento.Level == 4)
        {
            player.Moedas -= 80;
            empilhamento.Level = 5;
            VoltarButton.Select();
        }
    }

    public void Voltar()
    {
        UpgradePanel.SetActive(false);
        player.isMoving = true;
    }
}
