using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button restartButton;

    private void OnEnable()
    {
        homeButton.onClick.AddListener(() => { SceneManager.LoadScene("MainMenu"); });
        restartButton.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
    }
}
