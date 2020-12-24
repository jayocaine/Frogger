using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Player Controller containing all the main player events
/// Keeps track of player state such as lives, collectables, and wins.
/// </summary>
public class Player : MonoBehaviour
{
    #region -- Inspector Fields --

    /// <summary>
    /// Player Movement script
    /// </summary>
    public PlayerMovement playerMovement;

    /// <summary>
    /// The player mesh
    /// </summary>
    public Transform playerMesh;

    /// <summary>
    /// How many lives the player has at the beginning of the game
    /// </summary>
    public int lives = 3;

    /// <summary>
    /// How many second between dieing and reseting
    /// </summary>
    public float deathInterval = 2;

    #endregion

    #region -- Events --
    /// <summary>
    /// Called when the player loses a life
    /// </summary>
    public UnityEvent dead;

    /// <summary>
    /// Called when the player is reset after dieing
    /// </summary>
    public UnityEvent reset;

    /// <summary>
    /// Called when the player runs out of lives
    /// </summary>
    public UnityEvent gameover;
    #endregion

    #region -- Internal State --
    
    /// <summary>
    /// Keep track of the start position of the player movement controller
    /// </summary>
    Vector3 startPosition;
    #endregion

    #region -- Unity Event Handlers --
    /// <summary>
    /// Unity event handler
    /// </summary>
    private void Awake() {
        playerMovement.fall.AddListener(OnFall);
        startPosition = playerMovement.transform.position;
    }
    #endregion

    #region -- PlayerMovement Event Handler --
    /// <summary>
    /// PlayerMovement Event Handler
    /// </summary>
    private void OnFall() {
        StartCoroutine(OnFailCoroutine());
    }

    #endregion

    #region -- Private Animations --

    /// <summary>
    /// Started OnFail, disabled/enbaled movements while dead, and keeps track of lives
    /// </summary>
    /// <returns></returns>
    private IEnumerator OnFailCoroutine() {
        
        //Invoke dead event
        dead.Invoke();

        //Disable movement
        playerMovement.enabled = false;

        //Wait some time
        yield return new WaitForSeconds(deathInterval);

        //Move player back to original position
        playerMovement.transform.position = startPosition;
        
        //Snap player mesh back to original position
        playerMesh.position = startPosition;

        //If we run out lives invoke a gameover event
        lives--;
        if (lives == 0) {
            gameover.Invoke();
        }

        //Re-enable player movement
        playerMovement.enabled = true;

        //Invoke the reset event
        reset.Invoke();
    }
    #endregion

}
