using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    
    public float speed;
    private Vector2 move;

    public bool ispunch;
    public int Item;
    Empilhamento empilhamento;

    public bool isInteract;
    public bool isDeposito;

    public bool isLoja;

    public int Moedas;
    [SerializeField] Text currentMoedas;

    public bool isMoving;

    [SerializeField] SFXAudio audioSFX;
    [SerializeField] Loja loja;
     // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        empilhamento = GetComponent<Empilhamento>();
        isMoving = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            movePlayer();
        }
        
        currentMoedas.text = "Moedas: " + Moedas;

    }

    //Commands

    public void OnMove(InputAction.CallbackContext context)//Movement
    {
        move = context.ReadValue<Vector2>();  
        //isSell = false;
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if(movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if(move.x == 0 && move.y == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
            //animator.SetBool("isPunch", false);
        }
        
    }

    public void OnPunch(InputAction.CallbackContext context)//Soco
    {
        animator.SetBool("isPunch", true);
        
    }
    public void IsPuchOn()//Soco Ativado
    {
        ispunch = true;
        audioSFX.PlayPunchClip();
    }

    public void OnJump(InputAction.CallbackContext context)//Soco
    {
        animator.SetBool("isPunch", true);
        
    }

    public void OnInteract(InputAction.CallbackContext context)//Venda
    {
        isInteract = !isInteract;
    }

    public void OnTriggerEnter(Collider other) //Collision
    {
        Debug.Log("Colidiu");
        if(other.gameObject.tag == "Enemy" && ispunch == true)
        {
            if(empilhamento.Level > Item)
            {
                Item ++;
            }
            if(empilhamento.Level == Item)
            {
                Item = Item;
            }
            
            Debug.Log("Matou");
            
            Destroy(other.gameObject);
            
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Deposito" )
        {
            isDeposito = true;
            Debug.Log("Deposito");
            //Canvas para apertar x
            //Se apertar x e tiver itens, vende
            if(isInteract)
            {
                if(Item == 1)
                {
                    Moedas += 10;
                    audioSFX.PlayMoedasClip();
                    Item = 0;
                }
                else if(Item == 2)
                {
                    Moedas += 20;
                    audioSFX.PlayMoedasClip();
                    Item = 0;
                }
                else if(Item == 3)
                {
                    Moedas += 30;
                    audioSFX.PlayMoedasClip();
                    Item = 0;
                }
                else if(Item == 4)
                {
                    Moedas += 40;
                    audioSFX.PlayMoedasClip();
                    Item = 0;
                }
                else if(Item == 5)
                {
                    Moedas += 50;
                    audioSFX.PlayMoedasClip();
                    Item = 0;
                }
                empilhamento.Empilhament1.SetActive(false);
                empilhamento.Empilhament2.SetActive(false);
                empilhamento.Empilhament3.SetActive(false);
                empilhamento.Empilhament4.SetActive(false);
                empilhamento.Empilhament5.SetActive(false);
            }
            
            
        }

        if(other.gameObject.tag == "Loja" )
        {
            isLoja = true;
            Debug.Log("Loja");
            if(isInteract)
            {
                loja.UpgradePanel.SetActive(true);
                isMoving = false;
            }
        }
    }

    public void OnTriggerExit(Collider other) //Collision
    {
        if(other.gameObject.tag == "Deposito" )
        {
            isDeposito = false;
        }
    }

    public void punchOff()//Soco desativado
    {
        animator.SetBool("isPunch", false);
        ispunch = false;
    }

    

    
}
