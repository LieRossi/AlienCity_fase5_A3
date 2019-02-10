using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoController : MonoBehaviour {
    public float forca;
    public float distanciaDoRaio;
    public Rigidbody Alien_R;
    private bool cliqueiNoBotao, estouNoChao;
    private Animator anim;
    CharacterController cc;
    private bool jump = false;
    protected Vector3 gravidade = Vector3.zero;
    protected Vector3 move = Vector3.zero;




    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        anim.SetTrigger("Parado");
    }

    // Update is called once per frame
    void Update()
    {

    }


    void FixedUpdate()
    {

        RaycastHit raio;

        if (Physics.Raycast(transform.position, -transform.up, out raio, distanciaDoRaio))//se colidiu...
        {
            if (raio.collider)
            {
                estouNoChao = true;
            }
        }
        else //se não colidiu
        {
            estouNoChao = false;
        }
        if (estouNoChao)

        {
            if (cliqueiNoBotao == true)
            {
               
                Alien_R.AddForce(Vector3.up * forca * Time.deltaTime);
                //gravidade += Physics.gravity * Time.deltaTime;
                //gravidade.y = 6f;
                //move += gravidade;
                //cc.Move(move * Time.deltaTime);

                cliqueiNoBotao = false;
            }
            else
            {
                cliqueiNoBotao = false;
            }
        }
    }

    public void BotaoPular(bool cliquei)
    {
        cliqueiNoBotao = true;
        anim.SetTrigger("Pula");
        jump = true;
        gravidade += Physics.gravity * Time.deltaTime;
        gravidade.y = 10f;
        move += gravidade;
        cc.Move(move * Time.deltaTime);
        cliqueiNoBotao = false;
        jump = false;
    }

      

}
