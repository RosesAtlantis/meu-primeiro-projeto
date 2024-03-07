using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleControler : MonoBehaviour
{
    public float speed = 5f; //Seta velocidade

    public string movementAxisName = "Vertical";

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (isPlayer)
        {
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        }
        else
        {
            spriteRenderer.color = SaveController.Instance.colorEnemy;
        }
    }

    private void Update()
    {
        float moveInput = Input.GetAxis(movementAxisName); // Captura da entreda vertical, seta para baixo, teclas W e S)

        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime; // Calcula a nova posição da raquete baseada na velocidade

        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f); // Limita a posição da raquete para que ela não saia da tela. Math.Clamp delimita o range.

        transform.position = newPosition; // Atualiza a posição da raquete
    }
}
