using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField]private float speed = 5;
    private Vector3 velocity;
    public void MovePlayer(InputAction.CallbackContext context)
    {
        Vector2 input=context.ReadValue<Vector2>();
        velocity= new Vector3(input.x,0,input.y);
    }
    void Update()
    {
        Vector3 move = new Vector3(velocity.x,0,velocity.y);

        transform.position+=move*speed*Time.deltaTime;
    }
    
    public void setSpeed(float value)
    {
        speed+=value;
    }
}
