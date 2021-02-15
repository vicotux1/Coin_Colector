using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GM_sound : MonoBehaviour{
    public AudioMixer audiomixer;
    
    public GameObject load_text; 
    public void FxSound(float Fxvolumen){
       audiomixer.SetFloat("Fxvolumen",Fxvolumen) ;
    }
    public void MusicSound(float Musicvolumen){
       audiomixer.SetFloat("Soundvolumen",Musicvolumen) ;
    }
    void Awake(){
       StartCoroutine(LevelUI());
    }
    public void cursortrue(){
		Cursor.visible = true;
	}
    IEnumerator LevelUI(){
       load_text.SetActive(true);
        yield return new WaitForSeconds(8);
      load_text.SetActive(false);
      yield return new WaitForSeconds(2);
    }
   public void setResolution (int setResolution){
		if(setResolution==1){
		 Screen.SetResolution(848, 480, false);
			}if(setResolution==0){
		 Screen.SetResolution(1024, 600, false);
			}
			if(setResolution==2){
		 Screen.SetResolution(1280, 720, false);
			}
			if(setResolution==3){
		 Screen.SetResolution(1920, 1080, false);
			}
			Debug.Log("SetResolution "+setResolution);
		}
   public void antiAliasing_Quality (int Level){
	QualitySettings.antiAliasing = Level;
	Debug.Log("antiAliasing level "+Level);
	}   
}
