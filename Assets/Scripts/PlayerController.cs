using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   private Camera  mainCamera;
    private Rigidbody rb;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float rotationSpeed;
    
    private Vector2 movementDirection;
    
    void Start()
    {
        mainCamera =Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {   ProcessInput();
        KeepThePlayerOnScreen();
        RotateToFaceVelocity();
    }

    private void RotateToFaceVelocity()
    {   if(rb.velocity == Vector3.zero){return;}
       Quaternion targetRotation = Quaternion.LookRotation(rb.velocity,Vector3.back);
      transform.rotation= Quaternion.Lerp(transform.rotation,targetRotation,rotationSpeed*Time.deltaTime);
    }

    private void KeepThePlayerOnScreen()
    {   Vector3 newPosition = transform.position;

        Vector3 viewportPosition=mainCamera.WorldToViewportPoint(transform.position);
        
        if(viewportPosition.x>1)
        {  
            newPosition.x =-newPosition.x+0.1f;
            
        }
        else if (viewportPosition.x<0)
        {
            newPosition.x = -newPosition.x-0.1f;
        }
        else if( viewportPosition.y>1){
            newPosition.y = -newPosition.y+0.1f;
        }
        else if( viewportPosition.y<0){
            newPosition.y = -newPosition.y-0.1f;
        }
       transform.position = newPosition;
    }

    private void FixedUpdate() {
        if (movementDirection == Vector2.zero){return;}

        rb.AddForce(movementDirection*forceMagnitude*Time.deltaTime,ForceMode.Force);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }
    private void ProcessInput(){
            if(Touchscreen.current.primaryTouch.press.isPressed){
            Vector2 mousePosition = Vector2.zero;
           mousePosition= Touchscreen.current.primaryTouch.position.ReadValue();
           Vector2 worldPosition =mainCamera.ScreenToWorldPoint(mousePosition);
           movementDirection = worldPosition- new Vector2(transform.position.x, transform.position.y);
           movementDirection.Normalize();
        }
        else{
            movementDirection = Vector2.zero;
        }
    }
}
