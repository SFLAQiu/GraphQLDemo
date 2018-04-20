using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Model {
    public class MStudent {
        /// <summary>
        /// 学好
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 所在班级编号
        /// </summary>
        public int ClassId { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthdate { get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public MClass SClass { get; set; }
    }
}