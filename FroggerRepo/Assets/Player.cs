using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent gameover;
    public PlayerMovement playerMovement;
    public Vector3 startPosition;
    public int lives = 3;

    private void Awake() {
        playerMovement.fall.AddListener(OnFall);
        startPosition = playerMovement.transform.position;
    }

    private void OnFall() {
        playerMovement.transform.position = startPosition;
        lives--;
        if ( lives == 0) {
            gameover.Invoke();
        }
    }


}
