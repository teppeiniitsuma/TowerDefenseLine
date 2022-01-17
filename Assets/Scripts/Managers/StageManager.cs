using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum StateType {
    Idle,
    Pause,
    SoldierSet,
    LineStart,
    LineEnd, 
    EnemyMove,
    // FIX: GameManager‚Æ‚©‚ÉŽ‚½‚¹‚½•û‚ª‚¢‚¢‚©‚à
    GameOver,
    GameClear,
}

[DefaultExecutionOrder(-1)]
public class StageManager : MonoBehaviour {

    public static StageManager Instance;
    public StageData GetStageData => _stageData;
    public StateType GetState => _stateType;

    [SerializeField] private StageData _stageData;
    [SerializeField] private StateType _stateType;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Image _pausePopup;

    [HideInInspector] public List<Vector3> linePosList = new List<Vector3>();

    void Awake() {
        Instance = this;
        _pauseButton.onClick.AddListener(() => OnPauseBtn());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    public void StateChange(StateType type) {
        _stateType = type;
    }

    private StateType _tempState;

    private void OnPauseBtn() {
        if (_pausePopup.gameObject.activeInHierarchy) { 
            _pausePopup.gameObject.SetActive(false);
            _stateType = _tempState;
            return;
        }
        _tempState = _stateType;
        _stateType = StateType.Pause;
        _pausePopup.gameObject.SetActive(true);
        
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) { _stateType = StateType.LineStart; }
    }
}
