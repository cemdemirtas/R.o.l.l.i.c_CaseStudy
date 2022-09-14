using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UserInterfaceManager : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField]
    private Slider progressSlider;

    [Header("Texts")]
    [SerializeField]
    private Text countdownText;
    [SerializeField]
    private Text currentLevelText;
    [SerializeField]
    private Text nextLevelText;

    [Header("Objects")]
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private GameObject hand;
    [SerializeField]
    private GameObject resultsMenu;
    [SerializeField]
    private GameObject retryButton;
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private GameObject goodJob;
    [SerializeField]
    private GameObject levelFailed;
    [SerializeField]
    private GameObject super;
    [SerializeField]
    private GameObject fail;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject collectableLeaver;

    bool isGameFinished;
    bool isTouchedTheScreen;
    bool isGameCompleted;
    public static UserInterfaceManager userInterfaceManager;
    private void Awake()
    {
        if (userInterfaceManager == null)
        {
            userInterfaceManager = this;
        }
        //StartCoroutine(TutorialEffectsCoroutine());
        GameManager.OnLevelStarted += StartGame;

    }
    private void Start()
    {
      
        currentLevelText.text = (SaveAndLoadManager.saveAndLoadManager.GetLevelNumber() ).ToString();
        nextLevelText.text = (SaveAndLoadManager.saveAndLoadManager.GetLevelNumber() + 1).ToString();
        GameManager.OnLevelCompleted += FinishGame;
        GameManager.OnContinueLevel += OnGame;
        GameManager.OnLevelStarted?.Invoke();
    }
    void OnDisable()
    {
        GameManager.OnLevelCompleted -= FinishGame;
        GameManager.OnContinueLevel -= OnGame;
        GameManager.OnLevelStarted -= StartGame;

    }

    void Update()
    {
        if (!isTouchedTheScreen)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isTouchedTheScreen = true;
                StartCoroutine(GameStartCoroutine());
                //GameManager.OnContinueLevel?.Invoke();
            }
        }
    }

    IEnumerator TutorialEffectsCoroutine()
    {
        while (!isTouchedTheScreen)
        {
            hand.transform.DOLocalMoveX(-300, 1).OnComplete(() =>
            hand.transform.DOLocalMoveX(300, 1));

            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator GameStartCoroutine()
    {
        tutorial.transform.DOScale(Vector3.zero, 1);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            CountDownEffect();
            yield return new WaitForSeconds(1);
        }

        countdownText.text = "Start";
        CountDownEffect();
        if (collectableLeaver)
        {
            collectableLeaver.SetActive(true);
        }
        PlayerMovement.playerMovement.CanMove();
        yield return new WaitForSeconds(1);
    }

    IEnumerator GameFinishCoroutine()
    {
        isGameFinished = true;
        HideInGameUI();
        PlayerCollider.playerCollider.PlayerRotatorDeactive();
        yield return new WaitForSeconds(1);

        PlayerMovement.playerMovement.CantMove();
        //Debug.Log("CantMove");
        if (isGameCompleted && GameManager.gameState == GameManager.GameState.Win)
        {
            yield return new WaitForSeconds(3);
            //door.SetTrigger("isActive");
            DoorEffect();
            //Debug.Log("doorActive");
            SuperEffect();
            //Debug.Log("Super");
            yield return new WaitForSeconds(0.25f);

            PlayerMovement.playerMovement.CanMove();
            //Debug.Log("CanMove");
            yield return new WaitForSeconds(5);

            PlayerMovement.playerMovement.CantMove();
            showNextLevel();
            //Debug.Log("CantMove");
            Debug.Log("win");
                SaveAndLoadManager.saveAndLoadManager.SaveGame(
               (SaveAndLoadManager.saveAndLoadManager.GetLevelNumber() + 1));
        }
        else if (GameManager.gameState == GameManager.GameState.Failed)
        {
            yield return new WaitForSeconds(1);
            FailEffect();
            //Debug.Log("Fail");
            showRetry();
        }
        yield return new WaitForSeconds(1);

        ShowResults();
        //Debug.Log("Results");
    }

    public void HideInGameUI()
    {
        progressSlider.transform.DOScale(Vector3.zero, 1);
    }

    public void ShowProgress(float progress)
    {
        if (progress < 1)
        {
            progressSlider.value = progress;
        }
    }
    void showNextLevel()
    {

        retryButton.SetActive(false);
        nextButton.SetActive(true);
        levelFailed.SetActive(false);
        goodJob.SetActive(true);

    }
    void showRetry()
    {
        retryButton.SetActive(true);
        nextButton.SetActive(false);
        levelFailed.SetActive(true);
        goodJob.SetActive(false);

    }
    public void ShowResults()
    {

        resultsMenu.transform.DOScale(Vector3.one, 1);
    }

    public void IsGameCompleted(bool value)
    {
        isGameCompleted = value;
    }

    public void SuperEffect()
    {
        super.transform.DOScale(Vector3.one, 1).OnComplete(() =>
        super.transform.DOScale(Vector3.zero, 1));
    }

    public void FailEffect()
    {
        fail.transform.DOScale(Vector3.one, 1).OnComplete(() =>
        fail.transform.DOScale(Vector3.zero, 1));
    }

    public void CountDownEffect()
    {
        countdownText.gameObject.transform.DOScale(Vector3.one, 0.5f).OnComplete(() =>
        countdownText.gameObject.transform.DOScale(Vector3.zero, 0.5f));
    }

    public void DoorEffect()
    {
        door.gameObject.transform.DOLocalMoveY(20, 2).SetEase(Ease.InBounce);
    }

    public void FinishGame()
    {
        if (!isGameFinished)
        {
////            SaveAndLoadManager.saveAndLoadManager.SaveGame(
////(SaveAndLoadManager.saveAndLoadManager.GetLevelNumber() + 1));

            StartCoroutine("GameFinishCoroutine");
            Debug.Log("fnsh");
        }
    }
    public void StartGame()
    {

        StartCoroutine("TutorialEffectsCoroutine");
    }
    public void OnGame()
    {

        StartCoroutine("GameStartCoroutine");
    }
}
