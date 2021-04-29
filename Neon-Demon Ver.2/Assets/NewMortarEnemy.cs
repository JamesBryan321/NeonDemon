using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMortarEnemy : MonoBehaviour
{
    public GameObject Player;
    public LineRenderer linerenderer;
    public Transform point0, point1, point2;
    public int CurveHeight = 10;
    private int numPoints = 20;
    public Vector3[] positions = new Vector3[20];
    public GameObject Mortar;
    public GameObject AimLocation;
    public Transform firepoint;
    public float detection = 70;
    public float Firerate;
    public float nextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        linerenderer.positionCount = numPoints;
        DrawLinearCurve();
        Firerate = Random.Range(2f, 4.5f);
    }

    /*
    public void TestMortar()
    {
        
           GameObject mortar = Instantiate(Mortar, firepoint);
        mortar.GetComponent<MortarProjectile>().Followpositions = positions;
        point1.position = new Vector3((point0.position.x + point2.position.x) / 2, ((point0.position.y + point2.position.y) / 2) + CurveHeight, ((point0.position.z + point2.position.z) / 2));
        point2.position = Player.transform.position;
        Instantiate(AimLocation, point2);

    }
    */

    // Update is called once per frame
    void Update()
    {
        DrawLinearCurve();
        // point1.position = new Vector3((point0.position.x + point2.position.x) / 2 , ((point0.position.y + point2.position.y) / 2) + 10, ((point0.position.z + point2.position.z) / 2) );
        // point2.position = Player.transform.position
        if (Vector3.Distance(Player.transform.position, this.transform.position) < detection)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + Firerate;
                GameObject mortar = Instantiate(Mortar, firepoint);
                mortar.GetComponent<MortarProjectile>().Followpositions = positions;
                point1.position = new Vector3((point0.position.x + point2.position.x) / 2, ((point0.position.y + point2.position.y) / 2) + CurveHeight, ((point0.position.z + point2.position.z) / 2));
                point2.position = Player.transform.position;
                Instantiate(AimLocation, point2);
            }
        }

    }

    private void DrawLinearCurve()
    {
        for (int i = 1; i < numPoints + 1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalculateQuadraticBezierPoint(t, point0.position, point1.position, point2.position);
        }
        linerenderer.SetPositions(positions);
    }

    #region Bezier Maths
    private Vector3 CalculateLinerBezierPoint(float t, Vector3 p0, Vector3 p1)
    {
        return p0 + t * (p1 - p0);
    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }
    #endregion
}
