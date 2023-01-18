using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    /// <summary>
    /// demo方法帮助操作类
    /// </summary>
    public class MethodHelper : IGetDataType
    {
        /// <summary>
        /// 获取传入数据的数据类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public string GetType<T>(T a)
        {
            return a.GetType().ToString();
        }

        /// <summary>
        /// 获取传入参数相乘面积
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int GetArea(int a, int b)
        {
            return a * b;
        }
    }
}
