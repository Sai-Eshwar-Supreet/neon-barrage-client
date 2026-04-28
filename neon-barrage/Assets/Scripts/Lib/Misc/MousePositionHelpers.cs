using UnityEngine;
public static class MousePositionHelpers
{
    public static Vector3 GetMouseWorldPosition(Vector2 screenPosition) => GetMouseWorldPosition(screenPosition, Camera.main);
    public static Vector3 GetMouseWorldPosition(Vector2 screenPosition, Camera worldCamera)
    {
        Vector3 screenPosWithZ = screenPosition;
        screenPosWithZ.z = worldCamera.nearClipPlane;
        return worldCamera.ScreenToWorldPoint(screenPosWithZ);
    }
}
