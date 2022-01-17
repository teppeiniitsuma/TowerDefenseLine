using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    [SerializeField] private Button _nextSceneButton;

    void Start() {
        _nextSceneButton.onClick.AddListener(() => OnNextScene());
    }

    private void OnNextScene() {
        // ‰¼
        SelectSceneManager.SceneLoader(SceneType.Stage1);
    }
}
