using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaControler : MonoBehaviour
{
    // Criando uma variavel para achar meu rigidbody
    public Rigidbody2D meuRB;
    private Vector2 minhaVelocidade;

    public float velocidade = 5f;

    public float limiteHotizontal = 12f;

    public AudioClip boing;

    public Transform transformCamera;

    public float delay = 2f;

    private bool jogoIniciado = false;


    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        //iniciando a bola com um delay
            
        //diminuindo o valor do delay
        delay = delay - Time.deltaTime;
    
        if (delay <= 0 && jogoIniciado == false )
        {
            //alterando a variavel de controle
            jogoIniciado = true;

            {
                //passando a minha velocidade para a minha velocidade
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = velocidade;

                //tentando gerar um valor randoom
                int direcao = Random.Range(0, 4);
                if (direcao == 0)
                {
                    minhaVelocidade.x = +velocidade;
                    minhaVelocidade.y = +velocidade;
                }
                if (direcao == 1)
                {
                    minhaVelocidade.x = -velocidade;
                    minhaVelocidade.y = +velocidade;
                }
                if (direcao == 2)
                {
                    minhaVelocidade.x = -velocidade;
                    minhaVelocidade.y = -velocidade;
                }
                else
                {
                    minhaVelocidade.x = +velocidade;
                    minhaVelocidade.y = -velocidade;
                }
                Debug.Log(direcao);
                //adicionando velocidade para a esquerda
                meuRB.velocity = minhaVelocidade;
            }
        }
       










        float posicaoXDaBola = transform.position.x;
        //checando se a bola saiu da tela
        if (posicaoXDaBola >  limiteHotizontal ||  posicaoXDaBola < -limiteHotizontal)
        {
            //recarregando minha cena
            SceneManager.LoadScene(0);
        }
    }
    //criando meu evento de colisão 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //som para com quem eu colidir
        AudioSource.PlayClipAtPoint(boing,transformCamera.position);
        
    }
}
