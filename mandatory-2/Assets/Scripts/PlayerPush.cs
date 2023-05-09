using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPush : MonoBehaviour
{

    [SerializeField]
    private float push;
    [SerializeField] 
    private float kick;
    [SerializeField]
    private float kickHard;
    [SerializeField]
    private InputActionReference kickControl;
    [SerializeField]
    private InputActionReference kickHardControl;
    [SerializeField]
    private AudioSource kickSound;
    [SerializeField]
    private AudioSource kickHardSound;

    private float _forceMagnitude;

    private void OnEnable()
    {
        kickControl.action.Enable();
        kickHardControl.action.Enable();
    }
    
    private void OnDisable()
    {
        kickControl.action.Disable();
        kickHardControl.action.Disable();
    }
    
    private void Update()
    {
        if (kickControl.action.inProgress)
        {
            _forceMagnitude = kick;
        }
        else if (kickHardControl.action.inProgress)
        {
            _forceMagnitude = kickHard;
        }
        else
        {
            _forceMagnitude = push;
        }
    }
    
    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        Rigidbody rb = collision.collider.attachedRigidbody;
        if (rb != null)
        {
            Vector3 forceDir = collision.gameObject.transform.position - transform.position;
            forceDir.y = 0;
            forceDir.Normalize();
            
            rb.AddForceAtPosition(forceDir * _forceMagnitude, transform.position, ForceMode.Impulse);
            if (kickControl.action.inProgress)
            {
                kickSound.Play();
            }
            else if (kickHardControl.action.inProgress)
            {
                kickHardSound.Play();
            }
        }
    }

}
