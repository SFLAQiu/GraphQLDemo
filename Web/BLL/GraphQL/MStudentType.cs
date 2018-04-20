using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Model;

namespace Web.BLL.GraphQL {
    public class MStudentType : ObjectGraphType<MStudent> {
        private static BStudent _bll { get; set; }

        public MStudentType() {
            if (_bll == null) _bll = new BStudent();
            Field(d => d.Id).Description("学号");
            Field(d => d.Name).Description("学生名");
            Field(d => d.Age).Description("年龄");
            Field(d => d.Birthdate).Description("生日");
            Field<MClassType>("sclass", resolve: d => {
                //缓存中已经存在就直接返回
                if (d.Source.SClass != null) return d.Source.SClass;
                //从DB/缓存中获取数据
                var classId = d.Source?.ClassId ?? 0;
                if (classId > 0) d.Source.SClass = _bll.GetClass(d.Source.ClassId);
                return d.Source.SClass;
            },description:"班级信息");
        }
    }
}