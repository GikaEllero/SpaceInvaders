using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Invaders : MonoBehaviour
{
    public int linhas = 5;
    public int colunas = 11;    
    public Invader[] prefabs;
    public float dist = 0.8f;
    public float speed = 1.0f;
    private Vector3 _direcao = Vector2.right;
    public float direita = 4.0f;
    public float esquerda = -4.0f;


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
                Vector3 position = posicaoLinha;
                position.x += col *  dist;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Avanca(){
        _direcao.x *= -1;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _direcao * this.speed * Time.deltaTime;

        foreach (Transform invader in this.transform)
        {
            if(!invader.gameObject.activeInHierarchy)
                continue;

            if(_direcao == Vector3.right && invader.position.x >= direita){
                Avanca();
            }
            else if(_direcao == Vector3.left && invader.position.x <= esquerda){
                Avanca();
            }
        }
    }
}
