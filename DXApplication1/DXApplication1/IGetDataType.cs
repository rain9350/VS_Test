using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    /// <summary>
    /// demo接口
    /// </summary>
    public interface IGetDataType
    {
        string GetType<T>(T a);

        int GetArea(int a,int b);
    }
}
