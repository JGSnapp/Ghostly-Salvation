using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> _rope;
    [SerializeField] private Transform  _end, _start;
    [SerializeField] private GameObject _ropePref;
    void Start()
    {
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

