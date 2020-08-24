using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class Menu : MonoBehaviour
{
	public void Quit(){
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
		#endif
		}
		public void LevelSelect(string name){ 
		Game_Manager.estancia.Reset_game();
		SceneManager.LoadScene (name);
		}

	public void scene(string name){ 
		SceneManager.LoadScene (name);
		}
	public void Vsync(int Vsync){
		QualitySettings.vSyncCount = Vsync;}
}
