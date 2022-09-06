using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClassAcceptChooseHandler : MonoBehaviour
{
    [Header ("Script Objects")]
    [SerializeField] private CharacterCreateHandler _createCharacterManager;
    [SerializeField] private ClassSwitcher _classSwitcher;
    [SerializeField] private Intro _intro;

    [Header ("UI Objects")]
    [SerializeField] private GameObject _panelAcceptChoose;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;
    [SerializeField] private Image _imageAcceptChoose;
    [SerializeField] private Button _buttonClose;

    private Image _curtain;


    private void OnEnable()
    {
        _curtain = _panelAcceptChoose.GetComponent<Image>();

        _button.onClick.AddListener(StartIntro);
        _classSwitcher.SwitchClassButtonClicked += OnSwitchClass;
        _createCharacterManager.ButtonChooseClicked += OnButtonChooseClicked;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartIntro);
        _classSwitcher.SwitchClassButtonClicked -= OnSwitchClass;
        _createCharacterManager.ButtonChooseClicked -= OnButtonChooseClicked;
    }

    private void OnButtonChooseClicked()
    {
        _panelAcceptChoose.SetActive(true);
    }

    private void OnSwitchClass(int classID)
    {
        _text.text = $"Start as a {_createCharacterManager.CharacterViews[classID].Name} ?";
    }

    private void StartIntro()
    {
        _imageAcceptChoose.gameObject.SetActive(false);
        _buttonClose.gameObject.SetActive(false);

        StartCoroutine(CurtainFading());
    }

    private IEnumerator CurtainFading()
    {
        float alpha = 0;
        
        while (alpha < 1)
        {
            _curtain.color = new Color(0, 0, 0, alpha);
            alpha += Time.deltaTime;
            yield return null;
        }

        _intro.gameObject.SetActive(true);
    }
}
