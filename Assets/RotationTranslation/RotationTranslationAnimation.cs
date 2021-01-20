using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTranslationAnimation : MonoBehaviour
{

    /*ESPAÑOL
     *Solución por GameDevTraum
    * 
    * Artículo: https://gamedevtraum.com/es/descargar-assets/scripts-para-unity/script-de-rotacion-y-traslacion-para-gameobjects-en-unity/
    * Página: https://gamedevtraum.com/es/
    * Canal: https://youtube.com/c/GameDevTraum
    * 
    * Visita la página para encontrar más soluciones, Assets y artículos
   */


    [SerializeField][Range(1f, 15f)]float rotationX;
    [SerializeField][Range(1f, 15f)]float rotationY;
    [SerializeField][Range(1f, 15f)]float rotationZ;
    

    void FixedUpdate(){

        Rotation();       
    }

    private void Rotation(){
         transform.Rotate(rotationX, rotationY, rotationZ, Space.Self);
        }

}
