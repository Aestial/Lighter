using System.Collections;
using UnityEngine;

public interface ICollectable<T>
{
    void PointCount(T point);
}
