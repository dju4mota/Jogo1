using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_player : MonoBehaviour
{
    // stats 
    [SerializeField] private int speed;
    [SerializeField] private int vida;
    [SerializeField] private int dano;

    // pulo 
    public int jump_force;
    public bool segundo_pulo_up;
    private bool _on_ground;

    // animações 
    public int animacao;
     
    public enum Animacoes
    {
        idle,
        running,
        jumping,
        falling,
        attacking
    }


    public Vector2 _direction;
    public Rigidbody2D rig;
    public Main_player player;

    public bool On_ground { get => _on_ground; set => _on_ground = value; }


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Main_player>();
        rig = GetComponent<Rigidbody2D>();
        segundo_pulo_up = true;
    }

    // Update is called once per frame
    void Update()
    {
        check_move();
        check_attack();
    }

    void check_move()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);
        
        
        if(Input.GetKeyDown(KeyCode.Space) & On_ground)
        { 
            rig.velocity = new Vector2(rig.velocity.x, jump_force);
            animacao = (int)Animacoes.jumping;
        }
        if (Input.GetKeyDown(KeyCode.Space) & !On_ground & segundo_pulo_up)
        {
            rig.velocity = new Vector2(rig.velocity.x, jump_force);
            segundo_pulo_up = false;
            animacao = (int)Animacoes.jumping;
        }

        if (On_ground & rig.velocity.x !=0 & animacao != (int) Animacoes.attacking)
        {
                animacao = (int)Animacoes.running;
        }
        //Debug.Log(animacao);

        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void check_attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animacao = (int)Animacoes.attacking;
        }
    }
    
    public void attack(Inimigo inimigo){
        inimigo.perdeVida(dano);
    }

    public void perdeVida(int n)
    {
        vida -= n;
        dano += n;
    }
}
