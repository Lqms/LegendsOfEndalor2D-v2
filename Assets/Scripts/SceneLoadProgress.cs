using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class SceneLoadProgress : MonoBehaviour
{
    public static SceneLoadProgress Instance;

    [Header("Loading scene UI objects")]
    [SerializeField] private GameObject _panelLoadingScene;
    [SerializeField] private Image _imageLoadingSceneProgress;
    [SerializeField] private Text _textLoadingSceneProgress;
    [SerializeField] private Text _textLoadingSceneHint;

    private AsyncOperation _asyncOperationForLoadingScene;

    private void OnEnable()
    {
        if (Instance != null)
            Destroy(this);

        if (Instance == null)
            Instance = this;
    }

    private void OnDisable()
    {
        if (Instance == this)
            Instance = null;
    }

    public void LoadScene(AsyncOperation asyncOperation)
    {
        _asyncOperationForLoadingScene = asyncOperation;
        StartCoroutine(SceneLoading());
    }

    private IEnumerator SceneLoading()
    {
        // GetNewHintForLoadingPanel();
        _textLoadingSceneHint.text = "Cake is a lie";
        _panelLoadingScene.SetActive(true);
        // yield return new WaitForSeconds(1f);

        while (!_asyncOperationForLoadingScene.isDone)
        {
            float progress = _asyncOperationForLoadingScene.progress / 0.9f;
            _textLoadingSceneProgress.text = "Loading: " + string.Format("{0:0}%", progress * 100f);
            _imageLoadingSceneProgress.fillAmount = progress;
            yield return 0;
        }
    }
}
