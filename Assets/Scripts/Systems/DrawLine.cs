using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    
    [SerializeField] private SpriteRenderer _mouseObj;
    [SerializeField] private Transform[] _displayPoints;
    [SerializeField] private LineStartPosCheck linePosCheck;

    private LineRenderer _lineRenderer;
    private Camera _mainCamera;
    private Transform _mousePos;
    private int _positionCount;
    private bool _isline = false;

    void Start() {
        Init();
    }

    private void Init() {
        // LineRender setting
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.useWorldSpace = false;
        _lineRenderer.numCapVertices = 10;
        _lineRenderer.numCornerVertices = 10;
        _positionCount = 0;

        _mainCamera = Camera.main;
        _mousePos = _mouseObj.transform;
        transform.position = _mainCamera.transform.position + _mainCamera.transform.forward * 10;
        transform.rotation = _mainCamera.transform.rotation;
    }

    private bool PositionAddCheck(Vector3 pos) {
        var previousPos = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
        if (pos == previousPos) return false;
        return true;
    }

    private bool LineOverlapDetection(Vector3 pos) {
        var lineDatas = new Vector3[_lineRenderer.positionCount];
        _lineRenderer.GetPositions(lineDatas);
        foreach(var line in lineDatas) {
            if(pos == line) { return true; }
        }
        return false;
    }

    private bool isEnemyMove = false;

    private Vector3[] lines;
    int count = 0;

    void Update() {
        if (StageManager.Instance.GetState == StateType.Pause || 
            StageManager.Instance.GetState == StateType.GameOver ||
            StageManager.Instance.GetState == StateType.EnemyMove) return;
        
        if (Input.GetMouseButton(0)) {
            if (count != 0) count = 0;
            _mouseObj.enabled = true;
            // line位置チェック
            var pos = Input.mousePosition;
            pos.z = 10.0f;
            pos = _mainCamera.ScreenToWorldPoint(pos);

            if (pos.y < _displayPoints[1].position.y || _displayPoints[0].position.y < pos.y) return;
            pos = transform.InverseTransformPoint(pos);

            _mousePos.position = pos;
            if(!PositionAddCheck(pos)) { return; }
            if (!linePosCheck.GetPosCheck) return;

            isEnemyMove = false;
            _isline = true;
            _positionCount++;
            _lineRenderer.positionCount = _positionCount;
            _lineRenderer.SetPosition(_positionCount - 1, pos);
            StageManager.Instance.linePosList.Add(pos);
        }
        if (!(Input.GetMouseButton(0))) {
            if (_isline) {
                /*Debug.Log(LineOverlapDetection(lineRenderer.GetPosition(lineRenderer.positionCount - 1)));*/
                isEnemyMove = true;
                lines = new Vector3[_lineRenderer.positionCount];
                _lineRenderer.GetPositions(lines);
                _isline = false;
                StageManager.Instance.StateChange(StateType.LineEnd);
            }
            _positionCount = 0;
            _mouseObj.enabled = false;
            if (isEnemyMove) {
                StageManager.Instance.StateChange(StateType.EnemyMove);
            }
            //lineRenderer.positionCount = positionCount;
        }
    }

}
