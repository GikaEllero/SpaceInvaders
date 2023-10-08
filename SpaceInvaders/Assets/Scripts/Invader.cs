using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprite;
    public float animationTime = 1.0f;
    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;
    public System.Action killed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        if(_animationFrame >= this.animationSprite.Length)
            _animationFrame = 0;
        
        _spriteRenderer.sprite = this.animationSprite[_animationFrame];
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer == LayerMask.NameToLayer("Laser")){
            this.gameObject.SetActive(false);
            this.killed.Invoke();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }
}
