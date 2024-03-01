using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITypeMove
{
    Vector3 Move();
}

public class TypeMoveController : MoveController
{
    ITypeMove[] typesMoves;
    // Start is called before the first frame update
    void Start()
    {
        typesMoves = GetComponents<ITypeMove>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        foreach (ITypeMove typeMove in typesMoves)
        {
            direction += typeMove.Move();
        }
        Move(direction);
    }
}
