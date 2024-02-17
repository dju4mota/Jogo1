using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animation : MonoBehaviour
{

    public Animator animator;
    public Main_player player;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        check_animation();   
    }

    void check_animation()
    {

        switch (player.animacao) {
            case (int)Main_player.Animacoes.attacking:
                animator.Play("player_attacking");
                break;
            case (int)Main_player.Animacoes.jumping:
                animator.Play("player_jumping");
                break;
            case (int)Main_player.Animacoes.running:
                animator.Play("player_running"); 
                break;
            case (int)Main_player.Animacoes.falling:
                animator.Play("player_falling");
                break;
            default:
                animator.Play("player_idle");
                break;
        }

        if (player._direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (player._direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
}
