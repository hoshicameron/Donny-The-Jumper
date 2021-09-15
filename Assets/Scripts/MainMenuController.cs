using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button playerOneButton;
    [SerializeField] private Button playerTowButton;

    private void Awake()
    {
        playerOneButton.onClick.AddListener(() => { PlayGame(0);});
        playerTowButton.onClick.AddListener(() => { PlayGame(1);});
    }

    private void PlayGame(int index)
    {
        GameManager.Instance.CharacterIndex = index;
        SceneManager.LoadScene("GamePlay");
    }


}
