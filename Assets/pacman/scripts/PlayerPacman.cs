using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPacman : MonoBehaviour
{
    public float speed=1.0f;
    public string Horizontal="Horizontal", Vertical="Vertical";
    
    private Rigidbody rigidbody; 
    void Start(){
        rigidbody=GetComponent<Rigidbody>();
    }    void Update(){
    float H= Input.GetAxis(Horizontal);
    float V= Input.GetAxis(Vertical);    
    Mover(H, V);    
    }
    void Mover(float H, float V){
        Vector3 Move= (new Vector3 (H, 0,V)*speed)*Time.deltaTime;
        rigidbody.velocity=Move; 
    }
}
