using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TeaTimeInteractable : BasicInteractable
{
    public float difficultIncreaseFrequency;
    public float teatimeDuration;
    public Sprite tableWithCups;
    public Sprite tableWithoutCups;
    public Sprite bigTextbox;
    public Sprite smallTextbox;
    
    [SerializeField] private Text _text;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _textbox;
    [SerializeField] private Image _textboxImage;
    [SerializeField] private AudioController _audioController;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private QuunOMeter _quunOMeter;
    private int _difficultCounter = 0;
    private List<String> _currentDialogue = new List<string>();

    public override void Update()
    {
        
    }
    
    protected override void AddPlayerToOperateMachine(PlayerController playerController)
    {
        if (_playerControllers.Count == 0)
        {
            playerController.SetPlayerStatus(PlayerStatus.Busy);
            _playerControllers.Add(playerController); 
            playerController.Sit();
        }

        if (_playerControllers.Count > 0)
        {
            if (_playerControllers[0].downButton != playerController.downButton)
            {
                playerController.SetPlayerStatus(PlayerStatus.Busy);
                _playerControllers.Add(playerController); 
                playerController.Sit();
            }
        }

    }

    public override void ActivateMachine()
    {
    }

    public void TeaTime()
    {
        _alarmController.TurnOn();
        _state = InteractableState.Activated;
        //Invoke("Explode", teatimeDuration);
    }

    protected override void Explode()
    {
        
    }

    public void TeaTimeEnd()
    {
        if (_state == InteractableState.Activated)
        {
            _audioSource.Play();
            foreach (var playerController in _playerControllers)
            {
                playerController.StopDrinking();
                playerController.SetPlayerStatus(PlayerStatus.Free);
            } 
            _spriteRenderer.sprite = tableWithCups;
            IncreaseLevel();
            _quunOMeter.PissQueen();
        }
    }

    protected override void RunMinigame()
    {
        _audioController.PlayTeatimeMusic();
        _spriteRenderer.sprite = tableWithoutCups;

        foreach (var playerController in _playerControllers)
        {
            playerController.Drink();
        }
        
        _alarmController.TurnOff();
        _currentDialogue = DialoguesWrapper.dialogues[Random.Range(0, DialoguesWrapper.dialogues.Count)];
        
        FirstText();
        Invoke("SecondText", teatimeDuration/3);
        Invoke("ThirdText", (teatimeDuration/3) * 2);
        Invoke("EndDrinking", teatimeDuration);
    }

    private void FirstText()
    {
        _alarmController.TurnOff();
        _textbox.SetActive(true);
        _text.text = _currentDialogue[0];
        ChangeTextboxWidth(_text.text.Length);
    }

    private void SecondText()
    {
        _text.text = _currentDialogue[1];
        ChangeTextboxWidth(_text.text.Length);
    }

    private void ThirdText()
    {
        _text.text = _currentDialogue[2];
        ChangeTextboxWidth(_text.text.Length);
    }

    private void EndDrinking()
    {
        foreach (var playerController in _playerControllers)
        {
            playerController.StopDrinking();
            playerController.SetPlayerStatus(PlayerStatus.Free);
        }
        _spriteRenderer.sprite = tableWithCups;
        DeactivateMachine();
        _text.text = "";
        _textbox.SetActive(false);
        IncreaseLevel();
        Score.AddScore(DifficultLevel.GetDifficultLevel() * 5);
        _audioController.PlayNormalMusic();
        _quunOMeter.SatisfyQueen();
    }

    private void IncreaseLevel()
    {
        _difficultCounter = _difficultCounter + 1;
        if (_difficultCounter == difficultIncreaseFrequency)
        {
            DifficultLevel.IncreaseDifficultLevel();
            _difficultCounter = 0;
        }
    }

    private void ChangeTextboxWidth(int length)
    {
        if (length > 10)
        {
            _textbox.GetComponent<RectTransform>().sizeDelta = new Vector2 (456, 136);
            _textboxImage.sprite = bigTextbox;
        }
        else
        {
            _textbox.GetComponent<RectTransform>().sizeDelta = new Vector2 (304, 136);
            _textboxImage.sprite = smallTextbox;
        }
    }
}
