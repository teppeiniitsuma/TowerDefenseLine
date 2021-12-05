using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Stage Create/StageSetting")]
public class StageData : ScriptableObject {

    // Sprite
    public Sprite enemySprite;
    public Sprite backGroundSprite;

    // Stage
    public string stageName;
    public int enemyValue;

    // Line
    public Color lineColor = new Color(0,0,0,1);
    public bool  lineOverlap;
    
    // Position
    public Transform lineStartTrans;
    public Transform lineEndTrans;

    public Vector2 lineStartPos;
    public Vector2 lineEndPos;

    // Enemy Parameter
    public float enemyGeneratTime;
    public float enemyHealth;
    public float enemyMoveSpeed;

}
