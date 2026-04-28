
using System.Reflection;
using UnityEngine;

public static class GeneralHelpers
{
    public static void CopyValues<T>(this T Base, T Copy)
    {
        System.Type type = Base.GetType();
        foreach (FieldInfo field in type.GetFields())
        {
            field.SetValue(Copy, field.GetValue(Base));
        }
    }
    public static T GetComponentInAncestor<T>(this Transform transform) where T : Component
    {
        T comp = null;
        Transform currentParent = transform;

        while (currentParent != null)
        {
            comp = currentParent.GetComponent<T>();
            if (comp != null)
            {
                break;
            }

            currentParent = currentParent.parent;
        }

        return comp;
    }
}