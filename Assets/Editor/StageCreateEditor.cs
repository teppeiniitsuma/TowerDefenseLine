using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StageData))]
public class StageCreateEditor : Editor {

    private StageData data;
    private GUIStyle richLabel;

    private void Awake() {
        data = base.target as StageData;
        richLabel = new GUIStyle(EditorStyles.label);
        richLabel.richText = true;
    }

    public override void OnInspectorGUI() {

        serializedObject.Update();


        using (new GUILayout.VerticalScope(GUI.skin.box)) {
            // Title Label
            EditorGUILayout.LabelField("<b><color=#ff00ff>ステージ設定</color></b>", richLabel);
            GUILayout.Box("", GUILayout.Height(2), GUILayout.ExpandWidth(true));
            EditorGUILayout.Space();
            
            // Stage Setting
            data.stageName = EditorGUILayout.DelayedTextField("ステージ名", data.stageName);
            data.enemyValue = EditorGUILayout.IntField("エネミー数", data.enemyValue);
            EditorGUILayout.Space();
            
            // Sprites
            data.enemySprite = (Sprite)EditorGUILayout.ObjectField("Enemy画像", data.enemySprite, typeof(Sprite), true);
            GUILayout.Box("", GUILayout.Height(2), GUILayout.ExpandWidth(true));
            EditorGUILayout.Space();
            data.backGroundSprite = (Sprite)EditorGUILayout.ObjectField("背景画像", data.backGroundSprite, typeof(Sprite), true);
            GUILayout.Box("", GUILayout.Height(2), GUILayout.ExpandWidth(true));
            EditorGUILayout.Space();

            // Line Setting
            data.lineColor = EditorGUILayout.ColorField("Line Color", data.lineColor);
            data.lineOverlap = EditorGUILayout.Toggle("重なり判定", data.lineOverlap);
            GUILayout.Box("", GUILayout.Height(2), GUILayout.ExpandWidth(true));
            EditorGUILayout.Space();

            // Postion Setting
            data.lineStartTrans = (Transform)EditorGUILayout.ObjectField("Start Pos", data.lineStartTrans, typeof(Transform), true);
            if(data.lineStartTrans != null) {
                data.lineStartPos = EditorGUILayout.Vector2Field("Pos", data.lineStartTrans.position);
            }

            data.lineEndTrans = (Transform)EditorGUILayout.ObjectField("End Pos", data.lineEndTrans, typeof(Transform), true);
            if(data.lineEndTrans != null) {
                data.lineEndPos = EditorGUILayout.Vector2Field("Pos", data.lineEndTrans.position);
            }
            GUILayout.Box("", GUILayout.Height(2), GUILayout.ExpandWidth(true));
            EditorGUILayout.Space();

            // Enemy Parameter Setting
            data.enemyGeneratTime = EditorGUILayout.FloatField("Enemy Generat Time", data.enemyGeneratTime);
            data.enemyHealth = EditorGUILayout.FloatField("Enemy HP", data.enemyHealth);
            data.enemyMoveSpeed = EditorGUILayout.FloatField("Enemy Move Speed", data.enemyMoveSpeed);
            GUILayout.Box("", GUILayout.Height(2), GUILayout.ExpandWidth(true));
            EditorGUILayout.Space();


        }
        EditorGUILayout.Space();

        //serializedObject.ApplyModifiedProperties();
        //if (GUILayout.Button("Save")) {
        //    EditorUtility.SetDirty(data);
        //    AssetDatabase.SaveAssets();
        //}
    }
}