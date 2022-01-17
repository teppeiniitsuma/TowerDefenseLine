using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackField : MonoBehaviour, IAttaker {

    // çUåÇìoò^óp
    private Action _attackCall;

    [SerializeField] private float _attackTime = 2f;
    private float nowTime = 0;

    public void AddAttack(Action dam) {
        _attackCall += dam;
    }
    public void DeleteAttack(Action dam) {
        _attackCall -= dam;
        Debug.Log("eventDelete");
    }


    private void AttackTimer() {
        if (_attackCall != null) {
            if (nowTime < _attackTime) { nowTime += Time.deltaTime; }
            else {
                _attackCall();
                nowTime = 0;
            }
        }
        else {
            if (nowTime != 0) nowTime = 0;
        }
    }

    void Update() {
        if (StageManager.Instance.GetState != StateType.EnemyMove) return;
        AttackTimer();
    }

}
