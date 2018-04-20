using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Web.BLL;
using Web.BLL.GraphQL;
using LG.Utility;
namespace Web.Controllers {
    public class HomeController : ApiController {
        /// <summary>
        /// graphql demo 接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("query")]
        public object Test_Query() {
            var r = HttpContext.Current.Request;
            var query = r.GetF("query");
            var bll = new BStudent();
            var schema = new Schema { Query = new StudentQuery(bll), Mutation = new StudentMutation(bll) };
            var result = new DocumentExecuter()
                .ExecuteAsync(options => {
                    options.Schema = schema;
                    options.Query = query;
                }).GetAwaiter();
            var json = new DocumentWriter(indent: true).Write(result);
            return result.GetResult();
        }

        #region "辅助"
        ///《graphql 查询语句》
        ///
        ///【构造的graphql类型查询】
        ///query {
        ///    __type(name: "MStudentType") {
        ///        kind
        ///        name
        ///        fields {
        ///            name
        ///            description
        ///            type {
        ///                name
        ///            }
        ///        }
        ///    }
        ///}
        ///
        ///【查询-带参数:id】
        /// query{
        ///     student(id:1){
        ///         id
        ///         name
        ///         age
        ///     }
        /// }
        /// 
        ///【查询-别名，多id查询】
        ///query{
        ///    student1: student(id:3){
        ///        name
        ///        age
        ///    }
        ///    student2: student(id:5){
        ///        name
        ///        age
        ///    }
        ///}
        ///
        ///【查询-列表】
        ///query{
        ///    students{
        ///        id
        ///        name
        ///        age
        ///        sclass{
        ///            id
        ///            level
        ///            num
        ///            heads
        ///        }
        ///    }
        ///}
        ///【更新】
        ///mutation{
        ///    update(id:11,name:"33333"){
        ///        rt
        ///        msg
        ///    }
        ///}





        /// <summary>
        /// graphql 执行结果检测
        /// </summary>
        /// <param name="result"></param>
        private void CheckForErrors(ExecutionResult result) {
            if (result.Errors?.Count > 0) {
                var errors = new List<Exception>();
                foreach (var error in result.Errors) {
                    var ex = new Exception(error.Message);
                    if (error.InnerException != null) {
                        ex = new Exception(error.Message, error.InnerException);
                    }
                    errors.Add(ex);
                }
                throw new AggregateException(errors);
            }
        }
        #endregion
    }
}
