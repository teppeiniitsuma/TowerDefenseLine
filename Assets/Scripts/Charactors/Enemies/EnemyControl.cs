using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    private EnemyGenerator _enemGenerator = new EnemyGenerator();
    private GameObject[] _enemys;

    private float _generatTime;
    private float _nowTime = 0f;
    private int _count;

    void Start() {
        _enemys = new GameObject[StageManager.Instance.GetStageData.enemyValue];
        _generatTime = StageManager.Instance.GetStageData.enemyGeneratTime;
        for(int i = 0; i < _enemys.Length; i++) {
            _enemys[i] = _enemGenerator.GeneratEnemy();
        }
    }

    private void Timer(System.Action callback) {
        if(_nowTime < _generatTime) { _nowTime += Time.deltaTime; }
        else { callback(); _nowTime = 0; }
    }

    private void EnemyView() {
        if(_count == _enemys.Length) { return; }
        _enemys[_count].SetActive(true);
        _count++;
    }

    void Update() {
        if(StageManager.Instance.GetState == StateType.EnemyMove) {
            Timer(() => EnemyView());
        }
    }
}
