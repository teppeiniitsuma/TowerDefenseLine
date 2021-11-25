using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpdateLine : MonoBehaviour {
    
    [SerializeField] private float penSize = 0.6f;          // �M�̑���
    [SerializeField] private float uScrollSpeed = 0.18f;  // �e�N�X�`���̐L�т鑬�x
    
    [SerializeField] private Material _mat;

    private List<Vector3> points = new List<Vector3>();
    private List<Vector3> vertices = new List<Vector3>();
    private List<Vector2> uvs = new List<Vector2>();
    private List<int> tris = new List<int>();

    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshRenderer render;

    private int offset = 0;
    private float xoffset = 0;


    void Start() {
        meshFilter = GetComponent<MeshFilter>();
        render = GetComponent<MeshRenderer>();
    }

    void CreateMesh(float size) {
        Vector2 prev = this.points[this.points.Count - 2];
        Vector2 top = this.points[this.points.Count - 1];
        Vector2 dir = (top - prev).normalized;

        Vector2 plus90 = top + new Vector2(-dir.y, dir.x) * size;
        Vector2 minus90 = top + new Vector2(dir.y, -dir.x) * size;

        // ���_��ǉ�
        this.vertices.Add(minus90);
        this.vertices.Add(plus90);

        // UV��ǉ�
        this.uvs.Add(new Vector2(xoffset, 0));
        this.uvs.Add(new Vector2(xoffset, 1));
        xoffset += (top - prev).magnitude / 6.0f;////uScrollSpeed; 

        // �C���f�b�N�X��ǉ�
        this.tris.Add(offset);
        this.tris.Add(offset + 1);
        this.tris.Add(offset + 2);
        this.tris.Add(offset + 1);
        this.tris.Add(offset + 3);
        this.tris.Add(offset + 2);

        offset += 2;

        mesh.vertices = this.vertices.ToArray();
        mesh.uv = this.uvs.ToArray();
        mesh.triangles = this.tris.ToArray();

        meshFilter.sharedMesh = mesh;
        render.material = _mat;
    }

    public void PenDown(Vector3 tp) {
        // �J�n�_��ۑ�
        this.points.Add(tp);

        // ���_���Q����
        this.vertices.Add(tp);
        this.vertices.Add(tp);

        // uv���W��ݒ�
        this.uvs.Add(new Vector2(0, 1f));
        this.uvs.Add(new Vector2(0, 0));
        this.offset = 0;

        // ���b�V������
        this.mesh = new Mesh();
    }

    public void PenMove(Vector3 tp, float size) {
        this.points.Add(tp);

        CreateMesh(size);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            this.points.Clear();
            this.vertices.Clear();
            this.uvs.Clear();
            this.tris.Clear();

            Vector3 tp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PenDown(tp);
        }
        else if (Input.GetMouseButton(0)) {
            Vector3 tp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PenMove(tp, this.penSize);
        }
        else if (Input.GetMouseButtonUp(0)) {
            //meshFilter.sharedMesh = null;
        }
    }
}