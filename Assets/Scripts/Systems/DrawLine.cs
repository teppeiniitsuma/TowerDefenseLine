using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    
    [SerializeField] private GameObject mouseObj;
    [SerializeField] private Transform[] displayPoints;
    
    private LineRenderer lineRenderer;
    private Camera mainCamera;
    private Transform mousePos;
    private int positionCount;
    private bool isline = false;

    void Start() {
        Init();
    }

    private void Init() {
        // LineRender setting
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.numCapVertices = 10;
        lineRenderer.numCornerVertices = 10;
        positionCount = 0;

        mainCamera = Camera.main;
        mousePos = mouseObj.transform;
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * 10;
        transform.rotation = mainCamera.transform.rotation;
    }

    private bool PositionAddCheck(Vector3 pos) {
        var previousPos = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
        if (pos == previousPos) return false;
        return true;
    }

    private bool LineOverlapDetection(Vector3 pos) {
        var lineDatas = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(lineDatas);
        foreach(var line in lineDatas) {
            if(pos == line) { return true; }
        }
        return false;
    }

    private bool isEnemyMove = false;

    private Vector3[] lines;
    int count = 0;

    void Update() {
        if(StageManager.Instance.GetState == StateType.EnemyMove) return; 
        if (Input.GetMouseButton(0)) {
            if (count != 0) count = 0;
            mouseObj.SetActive(true);
            isEnemyMove = false;
            isline = true;
            var pos = Input.mousePosition;
            pos.z = 10.0f;
            pos = mainCamera.ScreenToWorldPoint(pos);

            if (pos.y < displayPoints[1].position.y || displayPoints[0].position.y < pos.y) return;
            pos = transform.InverseTransformPoint(pos);

            mousePos.position = pos;
            if(!PositionAddCheck(pos)) { return; }

            positionCount++;
            lineRenderer.positionCount = positionCount;
            lineRenderer.SetPosition(positionCount - 1, pos);
            StageManager.Instance.linePosList.Add(pos);
        }
        if (!(Input.GetMouseButton(0))) {
            if (isline) {
                /*Debug.Log(LineOverlapDetection(lineRenderer.GetPosition(lineRenderer.positionCount - 1)));*/
                isEnemyMove = true;
                lines = new Vector3[lineRenderer.positionCount];
                lineRenderer.GetPositions(lines);
                isline = false;
                StageManager.Instance.StateChange(StateType.LineEnd);
            }
            positionCount = 0;
            mouseObj.SetActive(false);
            if (isEnemyMove) {
                StageManager.Instance.StateChange(StateType.EnemyMove);
            }
            //lineRenderer.positionCount = positionCount;
        }
    }

}
