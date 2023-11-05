using UnityEngine;

public class WayPointNetwork : MonoBehaviour
{
    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = transform.GetChild(i).transform;
        }
    }
    public Transform GetPoint()
    {
        int index = Random.Range(0, _points.Length);
        return _points[index];
    }
}
