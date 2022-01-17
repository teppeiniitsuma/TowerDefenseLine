using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum SceneType {
    Title,
    // StageSceneだけでいい => ScriptableObjectで必要な物だけ切り替える
    Stage1,
    Stage2,
}

/// <summary>
/// SceneType拡張
/// </summary>
public static class SceneTypeExt {
    public static string SceneName(this SceneType sceneType) {
        string[] names = { "TitleScene", "Stage1", "Stage2", };
        return names[(int)sceneType];
    }
}

public static class SelectSceneManager {

    public static SceneType CurrentScene = SceneType.Title;

    /// <summary>
    /// シーン読み込み
    /// </summary>
    /// <param name="type"></param>
    public static void SceneLoader(SceneType type) {
        SceneManager.LoadScene(type.SceneName());
        CurrentScene = type;
    }

}
