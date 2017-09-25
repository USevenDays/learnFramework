using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour
{
    //网格模型顶点数量
    private int VERTICES_COUNT;

    [Header("边数为数组长度减1")]
    //顶点数组
    public Vector3[] vertices;
    //三角形数组
    int[] triangles;
    public float scale; //整体的缩放值
    //假定的值数组
    public float[] property;

    MeshFilter meshFilter;
    Mesh mesh;

    float pi = 3.1415f;
    void Start()
    {
        CreateMesh();
        SetVertices();
    }

    void OnGUI()
    {
        if (meshFilter == null)
        {
            CreateMesh();
            SetVertices();
        }

        if (GUILayout.Button("Apply "))
        {
            Apply();
        }
    }

    void CreateMesh()
    {
        meshFilter = (MeshFilter)GameObject.Find("radar").GetComponent(typeof(MeshFilter));
        mesh = meshFilter.mesh;
    }

    void SetVertices()
    {
        VERTICES_COUNT = vertices.Length;//顶点数等于数组长度，数组第一位是0点
        int triangles_count = VERTICES_COUNT - 1;//三角形数量等于边数

        triangles = new int[triangles_count * 3]; //三角形数组的大小是3的倍数,每2个顶点连接原点成一个三角形

         //设定原点坐标
         vertices[0] = new Vector3(0, 0, 1);
        //首个在x轴上的坐标点
        vertices[1] = new Vector3(45, 0, 1);

        //每个三角形角度
        float everyAngle = 360 / triangles_count;//除以三角形数，相当于除以边数，知道夹角
        //计算每个顶点应该在的位置
        for (int i = 2; i < vertices.Length; i++)
        {
            var angle = GetRadians(everyAngle * (i - 1));
            vertices[i] = new Vector3(45 * Mathf.Cos(angle), 45 * Mathf.Sin(angle), 1);
        }

        int idx = 0;//记录第几个三角形
        int value = 0;//除了原点不变，另外两点的值，持续增加
        for (int i = 0; i < triangles.Length; i++)
        {
            if (i % 3 == 0)
            {
                triangles[i] = 0;//三点一面
                value = idx;
                idx++;
            }
            else
            {
                value++;
                if (value == VERTICES_COUNT)//点数序列数超出，返回第一个点
                    value = 1;
                Debug.Log("value " + value);

                triangles[i] = value;
            }
        }

        //vertices[0] = new Vector3(0, 0, 1);
        //vertices[1] = new Vector3(45, 0, 1);
        //vertices[2] = new Vector3(45 * Mathf.Cos(GetRadians(75)), 45 * Mathf.Sin(GetRadians(75)), 1);
        //vertices[3] = new Vector3(-45 * Mathf.Cos(GetRadians(36)), 45 * Mathf.Sin(GetRadians(36)), 1);
        //vertices[4] = new Vector3(-45 * Mathf.Cos(GetRadians(36)), -45 * Mathf.Sin(GetRadians(36)), 1);
        //vertices[5] = new Vector3(45 * Mathf.Cos(GetRadians(75)), -45 * Mathf.Sin(GetRadians(75)), 1);


        //triangles[0] = 0;
        //triangles[1] = 1;
        //triangles[2] = 2;

        //triangles[3] = 0;
        //triangles[4] = 2;
        //triangles[5] = 3;

        //triangles[6] = 0;
        //triangles[7] = 3;
        //triangles[8] = 4;

        //triangles[9] = 0;
        //triangles[10] = 4;
        //triangles[11] = 5;

        //triangles[12] = 0;
        //triangles[13] = 5;
        //triangles[14] = 1;
    }
    /// <summary>
    /// 获取角度对应圆的关系
    /// </summary>
    /// <param name="angle">角度</param>
    /// <returns></returns>
    float GetRadians(float angle)
    {
        return pi / 180 * angle;
    }

    void Apply()
    {
        Vector3[] tmps = new Vector3[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            tmps[i] = vertices[i] * (property[i]/100) * scale;//所有顶点
        }

        mesh.vertices = tmps;
        //网格中顶点数量是通过赋予一个不同数量的顶点数组来改变。注意，如果你调整了顶点数组的大小，
        //那么所有其他顶点的属性（法线，颜色，切线，纹理坐标）将自动地调节大小。在为顶点赋值时，如果这个网格的顶点有没有被赋值的那么RecalculateBounds将自动被调用。 
        mesh.triangles = triangles;
        //这个数组是包含顶点数组索引的三角形列表。三角形数组的大小是3的倍数。顶点可以通过简单的索引来共享同一顶点。如果网格包含多个子网格（材质），
        //三角形列表将包含所有子网格的所有三角形。当你赋值三角形数组，subMeshCount是设置为1。如果你想要有多个子网格，使用subMeshCount和SetTriangles。 
    }
}
