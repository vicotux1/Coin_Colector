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
	[Range(1,3)][SerializeField]int _MenuID=1;
	public AudioClip Button;
	public GameObject mainmenu,options,levelEdit;
	private void Awake(){
		cursorfalse();
		if(_MenuID==1){
			mainmenuOn();
		}if(_MenuID==2){
			optionsOn();
		}if(_MenuID==3){
			levelEditOn();
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
		levelEdit.SetActive(false);
	}
	public void optionsOn(){
		mainmenu.SetActive(false);
		options.SetActive(true);
		levelEdit.SetActive(false);
	}
	public void levelEditOn(){
		mainmenu.SetActive(false);
		options.SetActive(false);
		levelEdit.SetActive(true);
	}		
		
	public void cursorF(string url){
		Application.OpenURL(url);
	}
	public void buttonsound() {
		Audio.clip =Button;
		Audio.Play();
		cursortrue();
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
		Game_Manager.estancia.music();
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
		public void fullScreen(bool Fullscreen){
	Screen.fullScreen = Fullscreen;
	}





}
