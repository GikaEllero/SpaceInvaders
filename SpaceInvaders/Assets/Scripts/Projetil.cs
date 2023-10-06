using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public Vector3 direcao;
    public float speed;
    public System.Action destroyed;

    public void OnTriggerEnter2D(Collider2D col){
        this.destroyed.Invoke();
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direcao * speed * Time.deltaTime;
    }
}
