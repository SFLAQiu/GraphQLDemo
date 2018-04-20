using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Model {
    public class MClass {
        public int Id { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 第几班
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 总人数
        /// </summary>
        public int Heads { get; set; }
    }
}