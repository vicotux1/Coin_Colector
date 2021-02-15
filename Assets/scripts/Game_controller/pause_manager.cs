#region Previas
using UnityEngine; 
using System.Collections; 
using UnityEngine.UI;
using UnityStandardAssets;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
#endregion
public class pause_manager : MonoBehaviour {
    public Canvas canvasPausa;
	#region Unity
	void Start(){
	canvasPausa.enabled = false;
	Time.timeScale = 1;
	Cursor.visible = false;
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
		void Update(){
		if (CrossPlatformInputManager.GetButtonDown ("Cancel")){
			Pause();
			Cursor.visible = !true;
			}
		}
	#endregion
	#region Pause		
    public void Pause(){
        canvasPausa.enabled = !canvasPausa.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1: 0;
		}
	#endregion
	#region quality	
	public void antiAliasing_Quality (int Level){
	QualitySettings.antiAliasing = Level;
	Debug.Log("antiAliasing level "+Level);
	}
	public void scene(string name){ 
	SceneManager.LoadScene (name);
	}
	public void Vsync(int Vsync){
	QualitySettings.vSyncCount = Vsync;
	}
	public void fullScreen(){
	Screen.fullScreen = !Screen.fullScreen;
	}

		
	public void Quit(){
     #if UNITY_EDITOR 
    EditorApplication.isPlaying = false;
    #else
    Application.Quit();
	#endif
	}
	#endregion
}
