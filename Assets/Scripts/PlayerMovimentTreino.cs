using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror; //biblioteca necessaria para nomear uma classe de NetworkBehaviour?simm

[RequireComponent(typeof(Rigidbody))] //para que serve?adiciona automaticamente, mas igual eu criei a referencia do rigidbody?

public class PlayerMovimentTreino : NetworkBehaviour // qual a diferença desta para a monobehaviour? serve para usar o islocalplayer
{
    public float velocidadeAndar;
    public float velocidadeGiro;
    private Rigidbody rigidbody_ref;


    private void Awake()
    {
        rigidbody_ref = GetComponent<Rigidbody>();//desnecessario por causa do [RequireComponent(typeof(Rigidbody))]?
    }

    private void Update()
    {
        if (isLocalPlayer)// serve para cada um controlar só seu personagem?sim
        {
            float r = Input.GetAxis("Horizontal"); //uma direção é um valor?
            float y = Input.GetAxis("Vertical");
            Movimento(r);
            Rotacao(y);
        }

        


    }
    public void Movimento(float Input)
    {
        float moviment = Input * velocidadeAndar * Time.deltaTime; //os 3 podem ser unidos em um valor?

        Vector3 direction = new Vector3(moviment, 0, 0);  

        rigidbody_ref.MovePosition(rigidbody_ref.position + direction); // Por que o rigidbody_ref.position deve ser somado ao direction? o rigidbody_ref.position atualiza posição

    }
    public void Rotacao(float Input)
    {
        float rotacao = Input * velocidadeGiro * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(0, rotacao, 0); //o euLer serve para converter para xyz

        rigidbody_ref.MoveRotation(rigidbody_ref.rotation * rotation); //Por que o rigidbody_ref.rotation deve ser multiplicado ao rotation? a multiplicação vai dar o efeito da rotação
    }

                                                                        


}
