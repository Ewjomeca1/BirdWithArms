using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Para conseguir acessar um script em outro, declare o script em si como uma variavel. Assim podendo utilizar ele em outros scripts.
    static public Player jogador;
    public HUD hud;
    public Personagem personagem;
    public string nome;
    private int pontos;
    CharacterController character;

    public ScriptableCharacter scriptable;

    float speed = 5f;

    float[] deslocamentoHorizontal = { -3, 0, 3 };
    int posicaoAtual = 1;

    private bool isSwipping = false;
    private Vector2 startingTouch;
    public int Pontos
    {
        get
        {
            return pontos;
        }
        set
        {
            pontos += value;

        }
    }
    void Movimentar()
    {
        Vector3 deslocaHorizontal = personagem.transform.position;



        if (Input.GetKeyDown("right") && posicaoAtual < 2)
        {

            posicaoAtual++;

        }

        if (Input.GetKeyDown("left") && posicaoAtual > 0)
        {

            posicaoAtual--;

        }

        float x = deslocamentoHorizontal[posicaoAtual] - personagem.transform.position.x;

        Vector3 dir = new Vector3(x * speed, 0, speed);

        personagem.transform.position += dir * Time.deltaTime;

        //Input Mobile
        if (Input.touchCount == 1)
        {
            if (isSwipping)
            {
                Vector2 diff = Input.GetTouch(0).position - startingTouch;
                diff = new Vector2(diff.x / Screen.width, diff.y / Screen.width);
                if (diff.magnitude > 0.01f)
                {
                    if (Mathf.Abs(diff.y) > Mathf.Abs(diff.x))
                    {
                        if (diff.y < 0)
                        {
                            //Slide();
                        }
                        else
                        {
                            //Jump();
                        }
                    }
                    else
                    {
                        if (diff.x < 0 && posicaoAtual  > 0)
                        {
                            posicaoAtual--;

                            deslocaHorizontal = new Vector3(deslocamentoHorizontal[posicaoAtual], personagem.transform.position.y, personagem.transform.position.z);
                            personagem.transform.position = deslocaHorizontal;
                        }
                        else if (diff.x > 0 && posicaoAtual < 2)
                        {
                            posicaoAtual++;

                            deslocaHorizontal = new Vector3(deslocamentoHorizontal[posicaoAtual], personagem.transform.position.y, personagem.transform.position.z);
                            personagem.transform.position = deslocaHorizontal;
                        }
                    }

                    isSwipping = false;
                }
            }
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startingTouch = Input.GetTouch(0).position;
                isSwipping = true;
            }

            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                isSwipping = false;
            }

        }



        /*
        Vector3 deslocaHorizontal = new Vector3 (0,0,0);
        if(Input.GetButtonDown("Direita") && posicaoAtual < 2)
        {
            posicaoAtual ++;
            
            deslocaHorizontal = new Vector3(deslocamentoHorizontal[posicaoAtual] , personagem.transform.position.y , personagem.transform.position.z);
            personagem.transform.position = deslocaHorizontal;
        }
        if(Input.GetButtonDown("Esquerda") && posicaoAtual > 0)
        {
            posicaoAtual --;
            
            deslocaHorizontal = new Vector3(deslocamentoHorizontal[posicaoAtual] , personagem.transform.position.y , personagem.transform.position.z);
            personagem.transform.position = deslocaHorizontal;
        }*/
        /*
        Vector3 movimenta;
        movimenta = new Vector3(deslocaHorizontal.x,0, personagem.speed) ;
        movimenta.y -= 10 * Time.deltaTime;
        character.Move(movimenta);
        */
    }
    private void Awake()
    {
        jogador = this;
    }
    void Start()
    {
        character = personagem.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentar();
        Cheat();

    }
    void Cheat()
    {
        if(Input.touchCount == 4)
        {
            SceneManager.LoadScene("Win");
        }
        if(Input.touchCount == 5)
        {
            scriptable.vidas = 999;
        }
    }

}
