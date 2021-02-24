using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class Menu : MonoBehaviour
{
	
	public AudioSource Audio;
	[Range(1,2)][SerializeField]int _MenuID=1;
	public AudioClip Button;
	public GameObject mainmenu,options;
	private void Awake(){
		cursorfalse();
		if(_MenuID==1){
			mainmenuOn();
		}if(_MenuID==2){
			optionsOn();
		}
	}
	public void Quit(){
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
		#endif
		}
	public void mainmenuOn(){
		mainmenu.SetActive(true);
		options.SetActive(false);
		
	}
	public void optionsOn(){
		mainmenu.SetActive(false);
		options.SetActive(true);
		
	}
 		
		
	public void cursorF(string url){
		Application.OpenURL(url);
	}
	public void buttonsound() {
		Audio.clip =Button;
		Audio.Play();
		cursortrue();
	}
	public void Shadows(int qualityIndex){
		
		if(qualityIndex==0){
			QualitySettings.shadowResolution=ShadowResolution.Low;
		}
		if(qualityIndex==1){
			QualitySettings.shadowResolution=ShadowResolution.Medium;
		}
		if(qualityIndex==2){
			QualitySettings.shadowResolution=ShadowResolution.High;
		}
			if(qualityIndex==3){
			QualitySettings.shadowResolution=ShadowResolution.VeryHigh;
			 
		}
	}
	public void vSync(int qualityIndex){
		
		if(qualityIndex==0){
			QualitySettings.vSyncCount = 0;
		}
		if(qualityIndex==1){
			QualitySettings.vSyncCount = 1;
		}
		if(qualityIndex==2){
			QualitySettings.vSyncCount = 2;
		}
	}
		
		public void LevelSelect(string name){ 
		Game_Manager.estancia.Reset_game();
		Game_Manager.estancia.music();
		SceneManager.LoadScene (name);
		}

	public void cursortrue(){
		Cursor.visible = true;
	}
	public void cursorfalse(){
		Cursor.visible = false;
	}		

	public void scene(string name){ 
		SceneManager.LoadScene (name);
		
		}
	public void SetQuality(int qualityIndex){
		if(qualityIndex==0){
			QualitySettings.SetQualityLevel(2);
			}
		if(qualityIndex==1){
			QualitySettings.SetQualityLevel(1);
			}
		if(qualityIndex==2){
			QualitySettings.SetQualityLevel(0);
			}	
		 
		}
		 /*switch (int index)
		{
			case 0:
			QualitySettings.SetQualityLevel(2);
			break;
			case 1:
			QualitySettings.SetQualityLevel(1);
			break;
			case 2:QualitySettings.SetQualityLevel(0);
			break;
		}*/
	public void fullScreen(bool Fullscreen){
	Screen.fullScreen = Fullscreen;
	}





}
