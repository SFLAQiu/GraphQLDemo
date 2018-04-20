using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Model {
    public class MResult {
        /// <summary>
        /// 输出结果,0=失败，1=成功
        /// </summary>
        public int rt { get; set; }
        /// <summary>
        /// 说明信息
        /// </summary>
        public string msg { get; set; }
    }
}