using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultControl : MonoBehaviour {

    [SerializeField] private GameObject _resultUI;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _selectStageButton;
    [SerializeField] private Button _titleButton;

    void Start() {
        _resultUI.SetActive(false);
        _restartButton.onClick.AddListener(() => OnRestartBtn());
        _selectStageButton.onClick.AddListener(() => OnSelectStageBtn());
        _titleButton.onClick.AddListener(() => OnTitleBtn());
    }

    private void OnRestartBtn() {
        SelectSceneManager.SceneLoader(SelectSceneManager.CurrentScene);
    }

    private void OnSelectStageBtn() {
        // Stage Select
    }

    private void OnTitleBtn() {
        SelectSceneManager.SceneLoader(SceneType.Title);
    }

    void Update() {
        if(StageManager.Instance.GetState == StateType.GameOver) {
            _resultUI.SetActive(true);
        }
    }
}
