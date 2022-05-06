using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista : MonoBehaviour
{
   
    public int tamanhoInicial;
    Pecas copiado;
    static public Pista pista;
    public List<Pecas> listaModulos,poolModulosPista, pista1, pista2,pista3;
    public float velocidade;
    private Vector3 posicaoPista;
    Vector3 posicao;
    public int tamanhoPool, cenarioAtual = 0, numMaxCenarios;
    int tamanhoCenario,modulosCenarioGerado = 0;
    

    private void movimentaPista()
    {
        posicaoPista.z -= velocidade;

        this.transform.position = posicaoPista;

    }
    public void GeraPista()
    {
        modulosCenarioGerado++;
        if (modulosCenarioGerado >= tamanhoCenario)
        {
            cenarioAtual++;
            if (cenarioAtual == numMaxCenarios)
            {
                cenarioAtual = 0;
            }

            if (cenarioAtual == 0)
            {
                listaModulos = pista1;
                
            }
            else if (cenarioAtual == 1)
            {
                listaModulos = pista2;
              
            }
            
            poolModulosPista.Clear();
            modulosCenarioGerado = 0;
            tamanhoCenario = listaModulos.Count * 3;
            
        }
        // 

        if (poolModulosPista.Count < tamanhoPool)
        {
            int ModuloSorteado = Random.Range(1, listaModulos.Count);
            posicao = copiado.conector.transform.position;
            copiado = Instantiate(listaModulos[ModuloSorteado], this.transform);
            copiado.transform.position = posicao;
           
        }
        else
        {
            int ModuloSorteado = Random.Range(0, poolModulosPista.Count);
            posicao = copiado.conector.position;
            copiado = poolModulosPista[ModuloSorteado];
            copiado.transform.position = posicao;
            reativaItens(poolModulosPista[ModuloSorteado].ItensColetaveis);
            poolModulosPista.RemoveAt(ModuloSorteado);
            
        }
        
    }
    private void reativaItens(GameObject listaItens)
    {
        int filhos = listaItens.transform.childCount;
        for(int i=0;i<filhos;i++)
        {
            listaItens.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        listaModulos = pista1;
        InvokeRepeating("movimentaPista", 2, 0.055f);
        posicaoPista = this.transform.position;
        tamanhoCenario = listaModulos.Count * 3;
        pista = this;
        copiado = Instantiate(listaModulos[0], this.transform);


        for (int i = 1; i < tamanhoInicial; i++)
        {
            GeraPista();
        }
    }

    
}
