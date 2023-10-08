using UnityEngine;

public class MysteryShip : MonoBehaviour
{
    public float shipRate = 5.0f;
    public int score = 100; 
    private Vector3 _direcao = Vector3.right;
    public float boundX = 6.0f;
    public float speed = 0.3f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            gameObject.SetActive(false);
            GameManager.SetScore(score);
        }
    }

    private void Move(){
        this.transform.position += _direcao * speed * Time.deltaTime;
    }

    private void Update(){
        if(_direcao == Vector3.right && transform.position.x >= boundX)
                _direcao = Vector3.left;
            
        else if(_direcao == Vector3.left && transform.position.x <= -boundX)
            _direcao = Vector3.right;
            
        InvokeRepeating(nameof(Move), this.shipRate, this.shipRate);
    }

}
