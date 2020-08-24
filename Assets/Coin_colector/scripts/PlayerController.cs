using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    [Range(1.0f, 200.0f)][SerializeField]private float speed=10.0f;
    public Vector3 Posicion_inicial;
    private float MovX, MovY;
    private Rigidbody rb;
    
    private void Awake() {
        rb=GetComponent<Rigidbody>();
        transform.position=Posicion_inicial;
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
    void OnTriggerEnter(Collider other){
        if (other.tag == "Enemy"){
			Game_Manager.estancia.Lives();
			rb.velocity=Vector3.zero;
			transform.position=Posicion_inicial;
			}
		}	
}
