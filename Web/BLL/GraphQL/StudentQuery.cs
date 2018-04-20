using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LG.Utility;

namespace Web.BLL.GraphQL {
    public class StudentQuery : ObjectGraphType {
        public StudentQuery(BStudent bll) {
            //查询-有参数id
            Field<MStudentType>("student", arguments: new QueryArguments(new QueryArgument<IntGraphType>() {
                Name = "id"
            }), resolve: d => {
                var id = d.Arguments["id"].GetInt(0, false);
                return bll.GetModel(id); ;
            });
            //查询-列表
            Field<ListGraphType<MStudentType>>("students", resolve: d => {
                return bll.GetStudents();
            });
        }
    }
}