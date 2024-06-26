using System;
using UniRx;

namespace UnityEngine.InputSystem
{
    public static class InputSystemExtensions
    {
        public enum Axis
        {
            Horizontal,
            Vertical
        }
        public static float AsAxis(this Vector2 vector, Axis axis)
        {
            return axis switch
            {
                Axis.Horizontal => vector.x,
                Axis.Vertical => vector.y,
                _ => throw new NotImplementedException(),
            };
        }

        public static IObservable<InputAction.CallbackContext> PerformedAsObservable(this InputAction action)
        {
            return Observable.FromEvent<InputAction.CallbackContext>(
                h => action.performed += h,
                h => action.performed -= h);
        }

        public static IObservable<InputAction.CallbackContext> StartedAsObservable(this InputAction action)
        {
            return Observable.FromEvent<InputAction.CallbackContext>(
                h => action.started += h,
                h => action.started -= h);
        }

        public static IObservable<InputAction.CallbackContext> CanceledAsObservable(this InputAction action)
        {
            return Observable.FromEvent<InputAction.CallbackContext>(
                h => action.canceled += h,
                h => action.canceled -= h);
        }
    }
}
