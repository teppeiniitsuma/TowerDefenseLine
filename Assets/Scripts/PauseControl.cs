using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour {

    [SerializeField] private Button _titleButton;
    [SerializeField] private Button _restartButton;

    void Start() {
        _titleButton.onClick.AddListener(() => OnTitleBtn());
        _restartButton.onClick.AddListener(() => OnRestartBtn());
    }

    private void OnTitleBtn() {
        SelectSceneManager.SceneLoader(SceneType.Title);
    }

    private void OnRestartBtn() {
        SelectSceneManager.SceneLoader(SelectSceneManager.CurrentScene);
    }
}
