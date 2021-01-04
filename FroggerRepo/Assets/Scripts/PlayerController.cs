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

    public string animationTriggerName = "Move";
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
        if (commandBuffer == Directions.Nothing) {
            return;
        }
        //rotate obj

        //set trigger

        switch (commandBuffer)
        {
            case Directions.Left:
                transform.rotation = Quaternion.Euler(0, -90, 0);
                
                break;
            case Directions.Right:
                transform.rotation = Quaternion.Euler(0, 90, 0);

                break;
            case Directions.Up:
                transform.rotation = Quaternion.Euler(0, 0, 0);

                break;
            case Directions.Down:
                transform.rotation = Quaternion.Euler(0, 180, 0);

                break;         
        }
        animationInProgress = true;
        commandBuffer = Directions.Nothing;
        anim.SetTrigger(animationTriggerName);
    }

    private void ReleaseTheAnimation() {
        animationInProgress = false;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            commandBuffer = Directions.Left;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            commandBuffer = Directions.Right;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            commandBuffer = Directions.Up;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            commandBuffer = Directions.Down;
        }
    }
}
