#region asignaciones previas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#endregion
public class Game_Manager : MonoBehaviour
{
    #region Variables publicas
    [Header ("Elementos UI")]
    public string main_Menu;
    public int Life, total_levels;
    public string next_level;
    [Header ("Music Background")]
    public AudioSource Fuente_audio;
	[Header ("Texto a mostrar")]
    public string _GameOver;
    public string _Next_level ;
	[Header ("Texto en UI")]
    public Text Puntos_text; 
    public Text nivel_text,live_text,highScore;
	[Header ("Points")]
    [SerializeField][Range (10, 500)]int MaxScore=10;
    public int _contador=0;
    [Header ("Audioclips")]
	public AudioClip Coin_Sound,Winer_Sound,Loose_Sound,Next_level_sound;
    #endregion
    #region Variables Private
    AudioSource Audio;
    int Lives_initial;
    int Contador_initial,Contador_total;
    Player Player;
    
    #endregion
    #region Funtions Unity
    private void Update() {
        live_text.text=" "+Life;
        }
    private void Awake() {
    LoadData();
    Player = FindObjectOfType<Player>();
    music(); 
    Cursor.visible = false;    
    live_text.text=" "+Life;
    Contador_initial=_contador; 
    Lives_initial=Life;   
    Audio=GetComponent<AudioSource>();
    singleton();
    }
     void SaveData(){
    if (Contador_total> PlayerPrefs.GetInt("HighScore", 0)){
    PlayerPrefs.SetInt("HighScore", Contador_total);
    highScore.text=Contador_total.ToString();
        }
    }
    void LoadData(){
    PlayerPrefs.GetInt("HighScore", Contador_total);
    highScore.text=Contador_total.ToString();
    }
    
    #endregion
    #region Sigleton
    public static Game_Manager estancia;
    private void singleton(){
    if (estancia!=null){
    Destroy(this.gameObject);      
    }else{estancia=this;
    DontDestroyOnLoad(this.gameObject);}
    }
    #endregion
    #region Text Update
    public void music(){
    Fuente_audio.enabled=true;  
    }     
    public void Reset_game(){
        _contador=Contador_initial; 
        Life=Lives_initial;
        Time.timeScale = Time.timeScale == 0 ? 1: 0;
        Fuente_audio.enabled=false;
        update_text();
        }
    public void update_text(){
        live_text.text=" "+Life;
        Puntos_text.text = "" +_contador;
    }    
    #endregion
    #region Score && lives
        public void Puntacion(int Value){
        _contador = _contador + Value;
        Audio.clip = Coin_Sound;
		Audio.Play();
		Puntos_text.text = "" +_contador;
		if( _contador>=MaxScore){
            StartCoroutine(Next_level());} 
        }
    public void Lives(){
        Life = Life -1;
        StartCoroutine(Coins());
		if( Life==0){
        Player.speed=0;
    StartCoroutine(GamOver());
    }
} 
    #endregion   
    #region Coroutine 
    IEnumerator Coins(){
        nivel_text.text="perdiste 1 vida, quedan "+ Life;
        Audio.clip = Loose_Sound;
		Audio.Play();
        yield return new WaitForSeconds(2);
         live_text.text=" "+Life;
         nivel_text.text="";
    }
    IEnumerator Next_level(){
        nivel_text.text="level Complete";
        Audio.clip = Next_level_sound;
		Audio.Play();
        yield return new WaitForSeconds(5);
        if(SceneManager.GetActiveScene ().buildIndex + 1<total_levels){ 
        nivel_text.text="";
        next_level=(SceneManager.GetActiveScene ().buildIndex + 1).ToString(); 
        //yield return new WaitForSeconds(5);
        //nivel_text.text="level:0"+(SceneManager.GetActiveScene ().buildIndex+1);
        }
        else if (SceneManager.GetActiveScene ().buildIndex + 1>=total_levels){
        nivel_text.text="You Win";
        Reset_game();
        update_text();
        next_level=main_Menu;
        }
        SceneManager.LoadScene (next_level);
        Contador_total=Contador_total+_contador;
        highScore.text=Contador_total.ToString();
        if (Contador_total> PlayerPrefs.GetInt("HighScore", 0)){
    PlayerPrefs.SetInt("HighScore", Contador_total);
    highScore.text=Contador_total.ToString();
        }
        _contador=0;
        
        yield return new WaitForSeconds(1);
        nivel_text.text=""; update_text();
    } 
    IEnumerator GamOver(){
        Audio.clip = Loose_Sound;
        
        nivel_text.text=_GameOver;
    
        yield return new WaitForSeconds(5);
        Puntos_text.text = "" +_contador;
        
        SaveData();
        Contador_total=0;highScore.text=0.ToString();

        //Destroy(gameObject,0.5f);
        SceneManager.LoadScene (main_Menu);

        Reset_game();
        update_text();
        Time.timeScale = Time.timeScale == 0 ? 1: 0;
    }
    
    #endregion
}
