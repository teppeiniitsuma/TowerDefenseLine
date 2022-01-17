using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public interface IDamager {
    void ApplyDamage();
}

public abstract class BaseEnemy : MonoBehaviour, IDamager {

    protected float health;
    protected float moveSpeed;
    protected int moveCount = 0;
    // �����������R�̖��O������
    private List<string> _soldierList = new List<string>();

    protected virtual void Awake() {
        health = StageManager.Instance.GetStageData.enemyHealth;
        moveSpeed = StageManager.Instance.GetStageData.enemyMoveSpeed;
    }
    public virtual void ApplyDamage() {
        health--;
        Debug.Log("�ɂ�:" + health.ToString());
        if (health <= 0) { 
            gameObject.SetActive(false);
            Debug.Log("���S����");
        }
    }

    /// <summary>
    /// �����Ŗ�����ʒu�܂ňړ�����
    /// �i�����������������Ǎ���̓x�^�ł��j
    /// </summary>
    protected virtual void EnemyMove(Vector3[] movePos) {
        if(movePos.Length == moveCount) { 
            gameObject.SetActive(false);
            StageManager.Instance.StateChange(StateType.GameOver);
            Debug.Log("test");
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, movePos[moveCount], Time.deltaTime * moveSpeed);
        if(transform.position == movePos[moveCount]) { moveCount++; }
    }

    protected virtual void Update() {
        if(StageManager.Instance.GetState == StateType.EnemyMove) {
            EnemyMove(StageManager.Instance.linePosList.ToArray());
        }
        Debug.Log(_soldierList.Count);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (_soldierList.Contains(collision.gameObject.name)) { Debug.Log("���ɂ�����"); return; }
        var att = collision.gameObject.GetComponent<IAttaker>();
        if (att == null) return;
        att.AddAttack(ApplyDamage);
        _soldierList.Add(collision.gameObject.transform.parent.name);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        var att = collision.gameObject.GetComponent<IAttaker>();
        if (att == null) return;
        att.DeleteAttack(ApplyDamage);
        // �o�^�������O���������S
        _soldierList.Remove(collision.gameObject.transform.parent.name);
    }

}
