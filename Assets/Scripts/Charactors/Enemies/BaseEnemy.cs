using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamager {
    void ApplyDamage();
}

public abstract class BaseEnemy : MonoBehaviour, IDamager {

    protected float health;
    protected float moveSpeed;
    protected int moveCount = 0;

    protected virtual void Awake() {
        health = StageManager.Instance.GetStageData.enemyHealth;
        moveSpeed = StageManager.Instance.GetStageData.enemyMoveSpeed;
    }
    public virtual void ApplyDamage() {
        health--;
        if (health <= 0) { 
            gameObject.SetActive(false);
            Debug.Log("死亡処理");
        }
    }

    /// <summary>
    /// 引数で貰った位置まで移動する
    /// （実装分けしたいけど今回はベタ打ち）
    /// </summary>
    protected virtual void EnemyMove(Vector3[] movePos) {
        if(movePos.Length == moveCount) { this.gameObject.SetActive(false); return; }
        transform.position = Vector3.MoveTowards(transform.position, movePos[moveCount], Time.deltaTime * moveSpeed);
        if(transform.position == movePos[moveCount]) { moveCount++; }
    }

    protected virtual void Update() {
        if(StageManager.Instance.GetState == StateType.EnemyMove) {
            EnemyMove(StageManager.Instance.linePosList.ToArray());
        }
    }

}
