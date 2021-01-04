using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public enum Directions{ 
        Nothing,
        Left,
        Right,
        Up,
        Down,
    }
    
    public Animator anim;
    public string animationTriggerName = "Move";
    public string wallLayer = "Walls";
    public string floorLayer = "Floors";
    public UnityEvent deathFromFall;
    private Directions commandBuffer = Directions.Nothing;
    private bool animationInProgress = false;

    private int wallLayerMask;
    private int floorLayerMask;

   

    private void Start()
    {
        wallLayerMask = LayerMask.GetMask(wallLayer);
        floorLayerMask = LayerMask.GetMask(floorLayer);
    }

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
        if (commandBuffer == Directions.Nothing) {
            return;
        }
        
        switch (commandBuffer)
        {
            case Directions.Left:
                //if there is a wall in the left direction return
                if (CollissionUtility.PointCollidesWithWorld(transform.position + Vector3.left, wallLayerMask))
                {
                    return;
                }
                transform.rotation = Quaternion.Euler(0, -90, 0); 
                break;
            case Directions.Right:
                if (CollissionUtility.PointCollidesWithWorld(transform.position + Vector3.right, wallLayerMask))
                {
                    return;
                }
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case Directions.Up:
                if (CollissionUtility.PointCollidesWithWorld(transform.position + Vector3.forward, wallLayerMask))
                {
                    return;
                }
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Directions.Down:
                if (CollissionUtility.PointCollidesWithWorld(transform.position + Vector3.back, wallLayerMask))
                {
                    return;
                }
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;         
        }
        animationInProgress = true;
        commandBuffer = Directions.Nothing;
        anim.SetTrigger(animationTriggerName);
    }

    private void ReleaseTheAnimation() {
        animationInProgress = false;



        //check what we're standing on      
        transform.parent = CollissionUtility.TransformAtPoint(transform.position + Vector3.down, floorLayerMask);
        if (transform.parent == null) {
            //dead
            deathFromFall.Invoke();
            return;
        }

        //Check if button is being held
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
