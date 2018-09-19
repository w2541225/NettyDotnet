using System;
using System.Collections.Generic;
using System.Text;

namespace IO.Netty.Util
{
    public interface ReferenceCounted
    {
        int RefCnt();
        ReferenceCounted Retain();
        ReferenceCounted Retain(int increment);
        ReferenceCounted Touch();
        ReferenceCounted Touch(Object hint);
        bool Release();
        bool Release(int decrement);
    }
}
