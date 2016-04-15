using UnityEngine;
using System.Collections;
using UniRx;

public interface IPlayerInput
{
    IObservable<bool> OnLeftButtonObservable  { get; }
    IObservable<bool> OnRightButtonObservable { get; }
}
