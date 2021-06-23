using System;
using System.Diagnostics.Contracts;
using biz.dfch.CS.Appclusive.Public;
using biz.dfch.CS.Commons;
using DictionaryParameters = biz.dfch.CS.Commons.DictionaryParameters;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public class ExecutionContext
    {

        public string Invoke(string modelName, string modelAction, string parameters)
        {
            Contract.Assert(!string.IsNullOrWhiteSpace(modelName));
            Contract.Assert(!string.IsNullOrWhiteSpace(modelAction));
            Contract.Assert(!string.IsNullOrWhiteSpace(parameters));

            var ctxParams = new ExecutionParameters()
            {
                ModelName = modelName,
                ModelAction = modelAction,
            };

            return Invoke(ctxParams, new DictionaryParameters(parameters))
                .SerializeObject();
        }

        public DictionaryParameters Invoke(ExecutionParameters ctxParams, DictionaryParameters parameters)
        {
            Contract.Assert(null != ctxParams);
            Contract.Assert(null != parameters);
            Contract.Ensures(null != Contract.Result<string>());

            var type = ActivatorExtensions.GetType(ctxParams.ModelName);
            Contract.Assert(null != type);
            var instance = Activator.CreateInstance(type, this) as IModelBase;
            Contract.Assert(null != instance);

            var result = instance.Initialise.Invoke(parameters);
            return result;
        }
    }
}
