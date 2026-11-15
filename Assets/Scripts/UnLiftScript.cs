using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLiftScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> _rope;
    [SerializeField] private Transform _end, _start;
    [SerializeField] private GameObject _ropePref, _lift;

    private float startPos1, startPos2, offset;
    void Start()
    {
        startPos1 = _lift.transform.position.y;
        startPos2 = transform.position.y;
        while (_rope[_rope.Count - 1].transform.position.y < _start.position.y)
        {
            GameObject LastRope;
            LastRope = Instantiate(_ropePref, _rope[_rope.Count - 1].transform.GetChild(0).transform);
            LastRope.transform.SetParent(_rope[_rope.Count - 1].transform.GetChild(0));
            _rope.Add(LastRope);

        }
    }
    void FixedUpdate()
    { 
        offset = startPos2 - transform.position.y;
        _lift.transform.position = new Vector3(_lift.transform.position.x, startPos1 + offset, _lift.transform.position.z);

        while (_rope[_rope.Count - 1].transform.position.y > _end.position.y)
        {
            Destroy(_rope[_rope.Count - 1]);
            _rope.RemoveAt(_rope.Count - 1);
        }
        while (_rope[_rope.Count - 1].transform.position.y < _start.position.y)
        {
            GameObject LastRope;
            LastRope = Instantiate(_ropePref, _rope[_rope.Count - 1].transform.GetChild(0).transform);
            LastRope.transform.SetParent(_rope[_rope.Count - 1].transform.GetChild(0));
            _rope.Add(LastRope);
        }
    }
}
