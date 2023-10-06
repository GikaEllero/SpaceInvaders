using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Projetil laserPrefab;
    private bool _laserActive = false;
    public float boundX = 4.0f;
    public float speed = 2.5f;
    public KeyCode moveLeft = KeyCode.LeftArrow;
    public KeyCode moveRight = KeyCode.RightArrow;

    public void Atirar()
    {
        if(!_laserActive){
            Projetil projetil = Instantiate(laserPrefab, transform.position, Quaternion.identity);  
            projetil.destroyed += LaserDestroyed;
            _laserActive = true;
        }
    }

    public void LaserDestroyed(){
        _laserActive = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    	if (Input.GetKey(moveRight))
        	transform.position += Vector3.right * speed * Time.deltaTime;
    	
    	else if (Input.GetKey(moveLeft))
        	transform.position += Vector3.left * speed * Time.deltaTime;

        var pos = transform.position;
    	if (pos.x > boundX) {
        	pos.x = boundX;
    	}
   	    else if (pos.x < -boundX) {
        	pos.x = -boundX;
    	}
    	transform.position = pos;

    	if (Input.GetKeyDown(KeyCode.Space))
            Atirar();

    }
}
