using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public UnityEvent fall;

    float nextInputTime = 0;
    public float interval;


    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }
    void DetectInput()
    {
        if ( Time.time < nextInputTime) {
            return;
        }        
        
        Vector3 oldPosition = transform.localPosition; //determine previous position after moving
               
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right);
        }
        if(oldPosition != transform.localPosition)
        {
            nextInputTime = Time.time + interval;

            //we have changed position
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
            {
                transform.parent = hit.transform;
            }
            else
            {
                //died
                fall.Invoke();
            }
        }
    }
}
