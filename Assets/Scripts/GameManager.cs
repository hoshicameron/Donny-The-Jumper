using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int CharacterIndex
    {
        get { return characterIndex; }
        set { characterIndex = value; }
    }

    [SerializeField] private List<GameObject> characterList;

    private int characterIndex;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded+=OnLevelFinishLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded-=OnLevelFinishLoading;
    }

    private void OnLevelFinishLoading(Scene scene, LoadSceneMode mode)
    {
        print(scene.name);
        if (scene.name == "GamePlay")
        {

            Instantiate(characterList[characterIndex],Vector3.zero, Quaternion.identity);
        }
    }
}
