using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Invaders : MonoBehaviour
{
    public int linhas = 5;
    public int colunas = 11;    
    public Invader[] prefabs;
    public float dist = 0.7f;
    public AnimationCurve speed;
    private Vector3 _direcao = Vector3.right;
    public float boundX = 6.0f;
    public int amountKilled {get; set;}
    public int totalAlive => totalInvaders - amountKilled;
    public int totalInvaders => linhas * colunas; 
    public float percKilled => (float)amountKilled / (float)totalInvaders;
    public float missilRate = 1.0f;
    public Projetil missilPrefab;

    private void Awake(){
        for (int linha = 0; linha < this.linhas; linha++)
        {
            float altura = dist * (this.linhas - 1);
            float largura = dist * (this.colunas - 1);
            Vector2 centro = new Vector2(-largura/2, -altura/2);
            Vector3 posicaoLinha = new Vector3(centro.x, centro.y + (linha * dist), 0.0f);
            for (int col = 0; col < this.colunas; col++)
            {
                Invader invader = Instantiate(this.prefabs[linha], this.transform);
                invader.killed += InvaderKilled;
                Vector3 position = posicaoLinha;
                position.x += col *  dist;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Avanca(){
        _direcao.x *= -1;

        Vector3 position = this.transform.position;
        position.y -= 0.5f;
        this.transform.position = position;
    }

    private void InvaderKilled(){
        amountKilled++;
    }

    private void Missil(){
        foreach (Transform invader in this.transform)
        {
            if(!invader.gameObject.activeInHierarchy)
                continue;

            if(Random.value < (1 / totalAlive)){
                Instantiate(missilPrefab, invader.position, Quaternion.identity);
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Missil), missilRate, missilRate);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _direcao * speed.Evaluate(percKilled) * Time.deltaTime;

        foreach (Transform invader in this.transform)
        {
            if(!invader.gameObject.activeInHierarchy)
                continue;

            if(_direcao == Vector3.right && invader.position.x >= boundX){
                Avanca();
            }
            else if(_direcao == Vector3.left && invader.position.x <= -boundX){
                Avanca();
            }
        }
    }
}
