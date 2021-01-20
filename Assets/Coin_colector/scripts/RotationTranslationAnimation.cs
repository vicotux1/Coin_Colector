using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTranslationAnimation : MonoBehaviour{
    [SerializeField][Range(1f, 15f)]float rotationX;
    [SerializeField][Range(1f, 15f)]float rotationY;
    [SerializeField][Range(1f, 15f)]float rotationZ;
    

    void FixedUpdate(){ Rotation();}
        void Rotation(){
         transform.Rotate(rotationX, rotationY, rotationZ, Space.Self);}

}
