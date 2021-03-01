using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour{
string AxisHorizontal="Horizontal",AxisVertical="Vertical";
Animator anim;

private void Awake() {
        anim=GetComponent<Animator>();
        
        }
 void FixedUpdate(){
        float MovX=Input.GetAxis(AxisHorizontal);
        float MovY=Input.GetAxis(AxisVertical);
        anim.SetFloat("SpeedY", MovY);
        anim.SetFloat("SpeedX", MovX);
    }
  
}
