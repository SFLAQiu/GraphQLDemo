using GraphQL.Types;
using LG.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Model;

namespace Web.BLL.GraphQL {
    public class StudentMutation : ObjectGraphType {
        public StudentMutation(BStudent bll) {
            Field<MResultType>("update", arguments: new QueryArguments(
                new QueryArgument<IntGraphType> {
                    Name = "id"
                },
                new QueryArgument<StringGraphType> {
                    Name = "name"
                }
            ), resolve: (d) => {
                var id = d.Arguments["id"].GetInt(0, false);
                var name = d.Arguments["name"].GetString("");
                if (id <= 0) return new MResult {
                    rt = 0,
                    msg = "非法学号"
                };
                if (name.IsNullOrWhiteSpace()) return new MResult {
                    rt = 0,
                    msg = "非法名字"
                };
                var isSc = bll.UpdateName(id, name);
                if (!isSc) return new MResult {
                    rt = 0,
                    msg = "更新失败"
                };
                return new MResult {
                    rt = 1,
                    msg = "bingo"
                };
            });
        }
    }
}