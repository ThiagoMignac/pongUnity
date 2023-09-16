using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaqueteControler : MonoBehaviour
{
    //criando meu vector 3 
    public Vector3 minhaPosicao;
    private float meuY;
    public float velocidade = 5f;
    public float meuLimite = 3.50f;

    //identificando se sou o player1
    public bool player1;

    //variavel para identificar se a raquete é uma inteligencia artificial 
    public bool ar = false;

    //pegando a posição da bola
    public Transform transformBola;


    // Start is called before the first frame update
    void Start()
    {
        //pegando a minha posição inicial e aplicando para minha posição
        minhaPosicao = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //passando meuY para o eixo Y da minhaPosicao
        minhaPosicao.y = meuY;
        //modificar a posição da minha raquete
        transform.position = minhaPosicao;
        //velocidade multiplicada pelo deltatime
        float deltaVelocidade = velocidade * Time.deltaTime;

        if (!ar)
        {
            //o eixo y para subir somente até meu limite
            //raquete player1
            if (player1)
            {
                //pegando o W para subir
                if (Input.GetKey(KeyCode.W))
                {
                    //aumentar o valor do meu Y
                    meuY = meuY + deltaVelocidade;

                }

                // formas diferentes de fazer isso em cima e abaixo 
                //pegando o S para descer
                if (Input.GetKey(KeyCode.S))
                {
                    //pegando o S para descer e só descer ate o meu limite 
                    if (Input.GetKey(KeyCode.S))
                    {
                        //aumentar o valor do meu Y
                        meuY = meuY - deltaVelocidade;
                    }
                }
            }
            //raquete player 2
            else
            {
                //meu codigo para colocar ele no automatico
                if (Input.GetKey(KeyCode.Space))
                    ar = true;


                //pegando o I para subir
                if (Input.GetKey(KeyCode.I))
                {
                    //aumentar o valor do meu Y
                    meuY = meuY + deltaVelocidade;
                }

                // formas diferentes de fazer isso em cima e abaixo 
                //pegando o S para descer
                if (Input.GetKey(KeyCode.K))
                {
                    //pegando o K para descer e só descer ate o meu limite 
                    if (Input.GetKey(KeyCode.K))
                    {
                        //aumentar o valor do meu Y
                        meuY = meuY - deltaVelocidade;
                    }
                }
            }

        }
        else
        {   //tirando ele do automatico
            //checando se tem alguem comandando o player 2
            if (Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.I))
            {
                ar = false;
            }
            //se a raquete estiver no automatico
            //meuY = transformBola.position.y;
            //para acessar funções matematicas , nós usamos a classe Mathf
            meuY = Mathf.Lerp(meuY, transformBola.position.y, 0.04f);
        }

        //impedindo que eu saia por baixo da tela
        if (meuY < -meuLimite)
        {
            meuY = -meuLimite;
        }
        //impedindo que eu saia por cima da tela
        if (meuY > meuLimite)
        {
            meuY = meuLimite;
        }
    }   
}
