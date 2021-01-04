using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Directions{ 
        Nothing,
        Left,
        Right,
        Up,
        Down,
    }
    private Directions commandBuffer = Directions.Nothing;
    private bool animationInProgress = false;
    
    public Animator anim;

  
    private void Update()
    {
        UpdateInput();
        ConsumeTheBuffer();
    }
    private void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            commandBuffer = Directions.Left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            commandBuffer = Directions.Right;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            commandBuffer = Directions.Up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            commandBuffer = Directions.Down;
        }
    }
    private void ConsumeTheBuffer() {
        if (animationInProgress) {
            return;
        }
        //start the animation
        switch (commandBuffer) {
            case Directions.Nothing:
                break;
            case Directions.Left:
                anim.SetTrigger("Left");
                animationInProgress = true;
                commandBuffer = Directions.Nothing;
                break;
            case Directions.Right:
                anim.SetTrigger("Right");
                animationInProgress = true;
                commandBuffer = Directions.Nothing;
                break;
            case Directions.Up:
                anim.SetTrigger("Up");
                animationInProgress = true;
                commandBuffer = Directions.Nothing;
                break;
            case Directions.Down:
                anim.SetTrigger("Down");
                animationInProgress = true;
                commandBuffer = Directions.Nothing;
                break;
        }
    }
    private void ReleaseTheAnimation() {
        animationInProgress = false;
    }
}
