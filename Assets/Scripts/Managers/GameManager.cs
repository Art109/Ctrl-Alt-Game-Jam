using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }


    private void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

    }
    #endregion
    private const int SCENE_MENU = 0; //cena principal - menu
    private const int SCENE_GAME = 1; //cena de jogo

    [Header("ATRIBUTOS CENA DE MENU")]
    [SerializeField] Button btnPlayGame;

    [Header("ATRIBUTOS CENA DE JOGO")]
    private Transform playerPosition; public Transform PlayerPosition { get => playerPosition;}

    void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == SCENE_MENU)
        {
            btnPlayGame.onClick.AddListener(OnClickButtonPlayGame);
        }
        if (SceneManager.GetActiveScene().buildIndex == SCENE_GAME)
        {
            playerPosition = FindObjectOfType<PlayerController>().transform;
        }
    }

    private void LoadScene(int sceneName){
        SceneManager.LoadScene(sceneName);
    }

    private void OnClickButtonPlayGame(){
        LoadScene(SCENE_GAME);
    }


    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().buildIndex == SCENE_MENU){
            btnPlayGame.onClick.RemoveAllListeners();
        }
    }
}
