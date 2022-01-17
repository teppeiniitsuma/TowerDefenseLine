using UnityEngine;

public class EnemyGenerator {

    public GameObject GeneratEnemy() {

        var generatEnemy = (GameObject)Resources.Load("Prefabs/EnemyObj");
        // gameObject Generat
        var obj = Object.Instantiate(generatEnemy, StageManager.Instance.GetStageData.lineStartPos, Quaternion.identity);
        // sprite Set
        obj.GetComponent<SpriteRenderer>().sprite = StageManager.Instance.GetStageData.enemySprite;
        var coll = obj.AddComponent<BoxCollider2D>();
        coll.isTrigger = true;
        obj.SetActive(false);
        return obj;
    }

    //private void Generator() {
    //    var instance = StageManager.Instance;
    //    var obj = new GameObject();
    //    obj.transform.position = instance.GetStageData.lineStartPos;
    //    obj.transform.localScale = new Vector3(0.3f, 0.3f, 1);

    //    var render = obj.AddComponent<SpriteRenderer>();
    //    render.sprite = instance.GetStageData.enemySprite;

    //    obj.transform.parent = this.transform;
    //    // Order in Layer == 2
    //    render.sortingOrder = 2;
    //    obj.AddComponent<NormalEnemy>();
    //}
}
