using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGenerator : MonoBehaviour
{

    public GameObject BodiesPart;
    public float DistBody;
    public List<Transform> _bodies;
    private Transform _transform;
    public float SpeedBody;
    public float PointsSnake;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
       
    }
   
    private void Update()
    {
        PointsSnake = _bodies.Count + 1;
        MoveBody(_transform.position);
        RipSnake();
    }

    private void MoveBody(Vector3 newPosition)
    {

        foreach (var chain in _bodies)
        {
            float squdDis = DistBody * DistBody;
            int namberChain = _bodies.IndexOf(chain);
            Vector3 xvector = Vector3.MoveTowards(chain.position, _transform.position, SpeedBody);
            Vector3 previosePosition = new Vector3(xvector.x, _transform.position.y, -(_transform.position.z + ((1 + namberChain) * DistBody)));

            if ((chain.position - _transform.position).sqrMagnitude > squdDis)
            {
                var temp = chain.position;
                chain.position = previosePosition;
                previosePosition = temp;
            }
            else
            {
                break;
            }
        }
        _transform.position = newPosition;
    }


   public void Eater()
    {
       
        {
            var chain = Instantiate(BodiesPart);
            _bodies.Add(chain.transform);
            PointsSnake++;
        }

    }

    public void Breaker()
    {
            if (_bodies.Count == 0){ return;}

            Destroy(_bodies[_bodies.Count-1].gameObject );
            _bodies.RemoveAt(_bodies.Count - 1);
           
        
        
    }
   public void RipSnake()
    {
        if(PointsSnake == -1f)
        {
            Destroy(gameObject);
        }
    }

}
