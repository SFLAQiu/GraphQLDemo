using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Model;

namespace Web.BLL.GraphQL {
    public class MResultType : ObjectGraphType<MResult> {
        public MResultType() {
            Field(d => d.rt);
            Field(d => d.msg);
        }
    }
}