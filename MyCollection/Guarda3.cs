using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Guarda3<T> : IEnumerable<T> {
    private T v1, v2, v3;
    public Guarda3() {
        v1 = default(T);
        v2 = default(T);
        v3 = default(T);
    }

    public void Add(T item) {
        if (v1.Equals(default(T))) {
            v1 = item;
        }
        else if (v2.Equals(default(T))) {
            v2 = item;
        }
        else if (v3.Equals(default(T))) {
            v3 = item;
        }
    }

    public IEnumerator<T> GetEnumerator() {
        yield return v1;
        yield return v2;
        yield return v3;
    }

    public T GetItem(int i) {
        switch (i) {
            case 1:
                return v1;
            case 2:
                return v2;
            case 3:
                return v3;
        }
        return default(T);
    }

    public void SetItem(int i, T item) {
        switch (i) {
            case 1:
                v1 = item;
                break;
            case 2:
                v2 = item;
                break;
            case 3:
                v3 = item;
                break;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
       return GetEnumerator();
    }
}

