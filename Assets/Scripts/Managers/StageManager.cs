using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum StateType {
    Idle,
    LineStart,
    LineEnd,
    EnemyMove,
}

[DefaultExecutionOrder(-1)]
public class StageManager : MonoBehaviour {

    public static StageManager Instance;
    public StageData GetStageData => _stageData;
    public StateType GetState => _stateType;

    [SerializeField] private StageData _stageData;
    [SerializeField] private StateType _stateType;

    [HideInInspector] public List<Vector3> linePosList = new List<Vector3>();

    void Awake() {
        Instance = this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    public void StateChange(StateType type) {
        _stateType = type;
    }

}
