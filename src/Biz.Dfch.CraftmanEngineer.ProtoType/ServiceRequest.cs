using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biz.dfch.CS.Commons;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public class ServiceRequest
    {
        public string Invoke(string json)
        {
            Contract.Assert(!string.IsNullOrWhiteSpace(json));

            var parameters = new DictionaryParameters(json);
            var ctxParams = new ExecutionParameters()
            {
                ModelName = parameters.Get("ModelName").ToString(),
                ModelAction = "InitialiseAction"
            };
            parameters.Remove("ModelName");
            parameters.Remove("ModelAction");

            var ctx = new ExecutionContext();
            var result = ctx.Invoke(ctxParams, parameters);

            return result.SerializeObject();
        }
    }
}
