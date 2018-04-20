using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Model;

namespace Web.BLL.GraphQL {
    public class MClassType : ObjectGraphType<MClass> {
        public MClassType() {
            Field(d => d.Level).Description("年级");
            Field(d => d.Heads).Description("人数");
            Field(d => d.Id).Description("编号");
            Field(d => d.Num).Description("班级");
        }
    }
}