using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SER_Dictionary<Tkey, TValue> : Dictionary<Tkey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] List<Tkey> _keys = new List<Tkey>();
    [SerializeField] List<TValue> _values = new List<TValue>();

    public void OnBeforeSerialize()
    {
        _keys.Clear();
        _values.Clear();

        foreach(KeyValuePair<Tkey,TValue> pair in this)
        {
            _keys.Add(pair.Key);
            _values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        this.Clear();
        if( _keys.Count != Values.Count )
        {
            Debug.Log("Keys count is not equal to value count");
        }

        for (int i = 0 ; i < _keys.Count; i++)
        {
            this.Add(_keys[i], _values[i]);
        }
    }

}
