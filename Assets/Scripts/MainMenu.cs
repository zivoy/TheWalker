using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject titleObj;

    public GameObject loadingHider;
    public GameObject loadingText;
    public Animator heroShipAnimator;

    private bool _showingUI;
    
    void Start()
    {
        startButton.SetActive(false);
        titleObj.SetActive(false);

        loadingHider.SetActive(false);
        loadingText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!heroShipAnimator.GetCurrentAnimatorStateInfo(0).IsName("ready")) return;
        if (_showingUI) return;
        _showingUI = true;

        StartCoroutine(animateMenuAppear());
    }

    IEnumerator animateMenuAppear()
    {
        titleObj.SetActive(true);
        
        yield return new WaitForSeconds(.3f);
        startButton.SetActive(true);
    }

    public void StartGame()
    {
        if (!startButton.activeSelf) return;

        heroShipAnimator.Play("leave");
        StartCoroutine(nextScene());
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(.6f); // change this to detect be based on when animator exits
        startButton.SetActive(false);
        titleObj.SetActive(false);
        
        loadingHider.SetActive(true);
        loadingText.SetActive(true);
        
        SceneManager.LoadScene(1);
    }
}
