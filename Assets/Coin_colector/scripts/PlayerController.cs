using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [Range(1.0f, 200.0f)][SerializeField]private float speed=10.0f;
    private float MovX, MovY;
    private void Awake() {
        rb=GetComponent<Rigidbody>();
        }

    void FixedUpdate(){
        Vector3 Move=new Vector3(MovX,0,MovY);
        rb.AddForce(Move*speed);
    }
    void OnMove(InputValue moveValue){
        Vector2 moveVector=moveValue.Get<Vector2>();
        MovX=moveVector.x;
        MovY=moveVector.y;
    }
}
