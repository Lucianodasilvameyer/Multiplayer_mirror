using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror; //biblioteca necessaria para nomear uma classe de NetworkBehaviour?

[RequireComponent(typeof(Rigidbody))] //para que serve?

public class PlayerMovimentTreino : NetworkBehaviour // qual a diferença desta para a monobehaviour?
{
    public float velocidadeAndar;
    public float velocidadeGiro;
    private Rigidbody rigidbody_ref;


    private void Awake()
    {
        rigidbody_ref = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float r = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Movimento(r);
        Rotacao(y);


    }
    public void Movimento(float Input)
    {
        float moviment = Input * velocidadeAndar * Time.deltaTime;

        Vector3 direction = new Vector3(moviment, 0, 0); //aqui como eu faria para andar no eixo y?, sendo que o mesmo ja esta responsavel pela rotação?  

        rigidbody_ref.MovePosition(rigidbody_ref.position + direction); // Por que o rigidbody_ref.position deve ser somado ao direction?

    }
    public void Rotacao(float Input)
    {
        float rotacao = Input * velocidadeGiro * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(0, rotacao, 0); //o euLer serve para suavizar a rotação?

        rigidbody_ref.MoveRotation(rigidbody_ref.rotation * rotation); //Por que o rigidbody_ref.rotation deve ser multiplicado ao rotation?
    }

                                                                        


}
