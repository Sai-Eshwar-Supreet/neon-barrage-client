using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    private readonly ObjectPool<PooledObject> pool;
    private readonly PooledObject prefab;
    private readonly Transform parent;

    public ObjectPoolManager(int poolCount, PooledObject prefab, Transform parent)
    {
        pool = new(createFunc: OnCreateObj, actionOnRelease: OnReleaseObj, actionOnDestroy: OnDestroyObj, defaultCapacity: poolCount);
        this.prefab = prefab;
        this.parent = parent;
    }

    private PooledObject InstantiateObject()
    {
        PooledObject poolObj = GameObject.Instantiate(prefab, parent);
        poolObj.gameObject.SetActive(false);
        poolObj.OnDeactivateObject += Release;
        return poolObj;
    }

    private PooledObject OnCreateObj()
    {
        return InstantiateObject();

    }
    private void OnReleaseObj(PooledObject obj)
    {
        obj.ContextTransform.SetParent(parent);
        obj.gameObject.SetActive(false);
    }

    private void OnDestroyObj(PooledObject obj)
    {
        GameObject.Destroy(obj.gameObject);
    }

    public PooledObject Get() => pool.Get();

    public void Release(PooledObject obj) => pool.Release(obj);
}
