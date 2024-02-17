using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    // stats 
    [SerializeField] private int speed;
    [SerializeField] private int vida;
    [SerializeField] private int dano;
    [SerializeField] private int direction = 1;
    
    public Main_player player;
    public Rigidbody2D rig;

    //public int Vida { get => vida; set => vida = value; }
    public void perdeVida(int n)
    {
        vida -= n;
        if(vida <= 0) { 
            Destroy(gameObject);
        }
    }

    void Update()
    {
        rig.velocity = new Vector2(direction * speed, rig.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if (collision.collider.tag == "Player")
            {
                player.perdeVida(dano);
            }
        }
    }
    public void changeDirection(int d)
    {
        direction = d;
    }
}
